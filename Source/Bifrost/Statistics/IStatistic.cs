﻿#region License
//
// Copyright (c) 2008-2013, Dolittle (http://www.dolittle.com)
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
using System.Collections.Generic;

namespace Bifrost.Statistics
{
    /// <summary>
    /// A statistic
    /// </summary>
    public interface IStatistic : IVisitableStatistic
    {
        /// <summary>
        /// The categories for this statistic
        /// </summary>
        IDictionary<string, ICollection<string>> Categories { get; }

        /// <summary>
        /// Record a category against this statistic
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="context">The context of this category</param>
        void Record(string context, string category);

        /// <summary>
        /// Sets the current context for recording statistics;
        /// </summary>
        /// <param name="context"></param>
        void SetContext(string context);
    }
}