﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Dashboard.Data
{
    public interface IConcurrentText
    {
        string ETag { get; }

        string Text { get; }
    }
}
