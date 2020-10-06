﻿using System;
using System.Text;
using Clima.Contracts.Models;

namespace Clima.Meadow.HackKit
{
    public class SerializationTests
    {
        public SerializationTests()
        {
        }

        public static void TestSystemJsonDeserializeWeather()
        {
            string json = @"[
                {
                    id: 1,
                    tempC: 22,
                    barometricPressureMillibarHg: 200,
                    relativeHumdity: 0.5
                }
            ]";
            //timeOfReading: '2020 - 10 - 05T14: 23:35.760476 - 07:00',

            System.Json.JsonArray climateReadings = System.Json.JsonArray.Parse(json) as System.Json.JsonArray;
            foreach (var climateReading in climateReadings) {
                Console.WriteLine($"ClimateReading; TempC:{climateReading["tempC"]}");
            }
        }

        ///// <summary>
        /////  this fails because System.Text.Json wants quotes around the property
        /////  names, but ASP.NET Core Web API doesn't serialize with quotes. how
        /////  is this library so bad?
        ///// </summary>
        //public static void TestSystemTextJsonDeserializeWeather()
        //{
        //    string json = @"[
        //        {
        //            id: 1,
        //            timeOfReading: '2020 - 10 - 05T14: 23:35.760476 - 07:00',
        //            tempC: 22,
        //            barometricPressureMillibarHg: 200,
        //            relativeHumdity: 0.5
        //        }
        //    ]";
        //    //timeOfReading: '2020 - 10 - 05T14: 23:35.760476 - 07:00',

        //    ClimateReading[] climateReadings = System.Text.Json.JsonSerializer.Deserialize<ClimateReading[]>(json);
        //    Console.WriteLine($"Deserialized temp: {climateReadings[0].TempC}");
        //}

        /// <summary>
        /// this works. 
        /// </summary>
        //public static void TestSystemTextJsonSerializeWeather()
        //{
        //    var climateReading = new ClimateReading {
        //        //TimeOfReading = DateTime.Now,
        //        BarometricPressureMillibarHg = 0.4m,
        //        TempC = 26,
        //        RelativeHumdity = 0.3m
        //    };

        //    string json = System.Text.Json.JsonSerializer.Serialize<ClimateReading>(climateReading);
        //    Console.WriteLine($"Serialize:\r\n {json}");
        //}

        //public static void TestSystemJsonDeserializeWeather()
        //{
        //    string json = @"[
        //        {
        //            id: 1,
        //            timeOfReading: '2020 - 10 - 05T14: 23:35.760476 - 07:00',
        //            tempC: 22,
        //            barometricPressureMillibarHg: 200,
        //            relativeHumdity: 0.5
        //        }
        //    ]";
        //    //timeOfReading: '2020 - 10 - 05T14: 23:35.760476 - 07:00',
        //    ClimateReading[] climateReadings = SimpleJson.SimpleJson.DeserializeObject<ClimateReading[]>(json)
        //    //Console.WriteLine($"Deserialized temp: {climateReadings[0].TempC}");
        //}


        //public static void TestNewtonSoftJsonDeserializeWeather()
        //{
        //    string json = @"[
        //        {
        //            id: 1,
        //            tempC: 22,
        //            barometricPressureMillibarHg: 200,
        //            relativeHumdity: 0.5
        //        }
        //    ]";
        //    //timeOfReading: '2020 - 10 - 05T14: 23:35.760476 - 07:00',

        //    ClimateReading[] climateReadings = Newtonsoft.Json.JsonConvert.DeserializeObject<ClimateReading[]>(json);

        //    Console.WriteLine($"Deserialized temp: {climateReadings[0].TempC}");
        //}

        //public static void TestNewtonSoftJsonSerializeWeather()
        //{
        //    var climateReading = new ClimateReading {
        //        //TimeOfReading = DateTime.Now,
        //        BarometricPressureMillibarHg = 0.4m,
        //        TempC = 26,
        //        RelativeHumdity = 0.3m
        //    };
        //    string json = Newtonsoft.Json.JsonConvert.SerializeObject(climateReading, Newtonsoft.Json.Formatting.Indented);
        //    Console.WriteLine($"Serialize:\r\n {json}");
        //}

        /// this won't work because SimpleJson also wants quotes.
        //public static void TestSimpleJsonDeserializeWeather()
        //{
        //    string json = @"[
        //        {
        //            id: 1,
        //            timeOfReading: '2020 - 10 - 05T14: 23:35.760476 - 07:00',
        //            tempC: 22,
        //            barometricPressureMillibarHg: 200,
        //            relativeHumdity: 0.5
        //        }
        //    ]";
        //    //timeOfReading: '2020 - 10 - 05T14: 23:35.760476 - 07:00',

        //    ClimateReading[] climateReadings = SimpleJson.SimpleJson.DeserializeObject<ClimateReading[]>(json);
        //    Console.WriteLine($"Deserialized temp: {climateReadings[0].TempC}");

        //}


    }
}
