﻿using System;
using Meadow.Gateways.Bluetooth;

namespace Clima.Meadow.Pro.Server.Bluetooth
{
    public class BluetoothServer
    {
        //==== internals
        Definition bleTreeDefinition;
        CharacteristicString tempCharacteristic;
        CharacteristicString pressureCharacteristic;
        CharacteristicString humidityCharacteristic;

        //==== controllers and such
        ClimateMonitor climateMonitor;

        //==== singleton stuff
        private static readonly Lazy<BluetoothServer> instance =
            new Lazy<BluetoothServer>(() => new BluetoothServer());
        public static BluetoothServer Instance {
            get { return instance.Value; }
        }

        private BluetoothServer()
        {
            Initialize();

            MeadowApp.Device.BluetoothAdapter.StartBluetoothServer(bleTreeDefinition);
        }

        protected void Initialize()
        {
            climateMonitor = ClimateMonitor.Instance;
            bleTreeDefinition = GetDefinition();

            climateMonitor.ClimateConditionsUpdated += ClimateMonitor_ClimateConditionsUpdated;
        }

        private void ClimateMonitor_ClimateConditionsUpdated(object sender, Models.ClimateConditions climateConditions)
        {
            Console.WriteLine("New climate data, setting BLE characteristics.");
            if(climateConditions.New?.Temperature is { } temp) {
                tempCharacteristic.SetValue($"{ temp.Fahrenheit:N2}°F");
            }
            if (climateConditions.New?.Pressure is { } pressure) {
                pressureCharacteristic.SetValue($"{ pressure.Pascal:N2}hPa");
            }
            if (climateConditions.New?.Humidity is { } humidity) {
                humidityCharacteristic.SetValue($"{ humidity:N2}%");
            }
        }

        protected Definition GetDefinition()
        {
            //==== create our charactistics
            // temperature
            tempCharacteristic = new CharacteristicString(
                    "Temperature",
                    uuid: "e78f7b5e-842b-4b99-94e3-7401bf72b870",
                    permissions: CharacteristicPermission.Read,
                    properties: CharacteristicProperty.Read,
                    maxLength: 32
                );
            // pressure
            pressureCharacteristic = new CharacteristicString(
                    "Pressure",
                    uuid: "2d45f026-d8ea-4d47-813a-13e8f788d328",
                    permissions: CharacteristicPermission.Read,
                    properties: CharacteristicProperty.Read,
                    maxLength: 32
                );
            // humidity
            humidityCharacteristic = new CharacteristicString(
                    "Humidity",
                    uuid: "143a3841-e244-4520-a456-214e048a030f",
                    permissions: CharacteristicPermission.Read,
                    properties: CharacteristicProperty.Read,
                    maxLength: 32
                );

            //==== BLE Tree Definition
            var definition = new Definition(
                "Meadow Clima",
                new Service(
                    "Weather_Conditions",
                    896,
                    tempCharacteristic,
                    pressureCharacteristic,
                    humidityCharacteristic
                ));
            return definition;
        }
    }
}
