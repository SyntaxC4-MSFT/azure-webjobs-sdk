﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.WebJobs.Host.Storage.Queue;

namespace Microsoft.Azure.WebJobs.Host.Queues.Triggers
{
    internal class StorageQueueMessageToStringConverter : IConverter<IStorageQueueMessage, string>
    {
        public string Convert(IStorageQueueMessage input)
        {
            return input.AsString;
        }
    }
}
