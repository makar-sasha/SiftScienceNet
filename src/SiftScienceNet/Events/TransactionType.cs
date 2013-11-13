﻿using System;
using Newtonsoft.Json;

namespace SiftScienceNet.Events
{
    public enum TransactionType
    {
        Sale,
        Authorize,
        Capture,
        Void,
        Refund
    }

    public class TransactionTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var transactionType = (TransactionType)value;

            if (transactionType == TransactionType.Sale)
                writer.WriteValue("$sale");

            if (transactionType == TransactionType.Authorize)
                writer.WriteValue("$authorize");

            if (transactionType == TransactionType.Capture)
                writer.WriteValue("$capture");

            if (transactionType == TransactionType.Void)
                writer.WriteValue("$void");

            if (transactionType == TransactionType.Refund)
                writer.WriteValue("$refund");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TransactionType);
        }
    }
}