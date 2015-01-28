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

namespace Bifrost.Mapping
{
    /// <summary>
    /// The exception that is thrown when one asks for a map for unknown combination of source and target
    /// </summary>
    public class MissingMapException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MissingMapException"/>
        /// </summary>
        /// <param name="source"><see cref="Type">Source type</see></param>
        /// <param name="target"><see cref="Type">Target type</see></param>
        public MissingMapException(Type source, Type target) : base(string.Format("Missing map for given combination of '{0}' (SOURCE) and '{1}' (TARGET)", source.FullName, target.FullName))
        {

        }
    }
}