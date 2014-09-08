﻿#region License
//
// Copyright (c) 2008-2014, Dolittle (http://www.dolittle.com)
//
// Licensed under the MIT License (http://opensource.org/licenses/MIT)
//
// You may not use this file except in compliance with the License.
// You may obtain a copy of the license at 
//
//   http://github.com/dolittle/Bifrost/blob/master/MIT-LICENSE.txt
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
using System;
using Bifrost.Rules;

namespace Bifrost.Validation.Rules
{
    /// <summary>
    /// Represents the <see cref="ValueRule"/> for greater than - any value must be greater than a given value
    /// </summary>
    public class GreaterThan<T> : ValueRule
        where T:IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GreaterThan"/> 
        /// </summary>
        /// <param name="value">Value that the input value must be greater than</param>
        public GreaterThan(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value that input value must be greater than
        /// </summary>
        public T Value { get; private set; }

#pragma warning disable 1591 // Xml Comments
        public override bool IsSatisfiedBy(IRuleContext context, object instance)
        {
            ThrowIfValueTypeMismatch<T>(instance);
            return ((IComparable<T>)instance).CompareTo(Value) > 0;
        }
#pragma warning restore 1591 // Xml Comments
    }
}
