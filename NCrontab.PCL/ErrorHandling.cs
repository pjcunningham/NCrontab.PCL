﻿#region License, Terms and Author(s)
//
// NCrontab - Crontab for .NET
// Copyright (c) 2008 Atif Aziz. All rights reserved.
//
//  Author(s):
//
//      Atif Aziz, http://www.raboof.com
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

namespace NCrontab
{
    #region Imports

    using System;
    using System.Diagnostics;

    #endregion

    /// <summary>
    /// Represents the method that will handle an <see cref="Exception"/> object.
    /// </summary>

    public delegate void ExceptionHandler(Exception e);

    /// <summary>
    /// Represents the method that will generate an <see cref="Exception"/> object.
    /// </summary>
    
    public delegate Exception ExceptionProvider();

    /// <summary>
    /// Defines error handling strategies.
    /// </summary>

    internal static class ErrorHandling
    {
        /// <summary>
        /// A stock <see cref="ExceptionHandler"/> that throws.
        /// </summary>

        public static readonly ExceptionHandler Throw = e => { throw e; };

        internal static ExceptionProvider OnError(ExceptionProvider provider, ExceptionHandler handler)
        {
            Debug.Assert(provider != null);

            if (handler != null)
                handler(provider());
            
            return provider;
        }
    }
}
