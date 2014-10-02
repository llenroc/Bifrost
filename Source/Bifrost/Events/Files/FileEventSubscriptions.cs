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
using System.Collections.Generic;
using System.IO;
using Bifrost.Serialization;

namespace Bifrost.Events.Files
{
    /// <summary>
    /// Represents an implementation of <see cref="IEventSubscriptions"/>
    /// </summary>
    public class FileEventSubscriptions : IEventSubscriptions
    {
        FileEventStoreConfiguration _configuration;
        ISerializer _serializer;

        /// <summary>
        /// Initializes a new instance of <see cref="FileEventSubscriptions"/>
        /// </summary>
        /// <param name="configuration"><see cref="FileEventStoreConfiguration"/> to use for configuration</param>
        /// <param name="serializer"><see cref="ISerializer"/> to use for serialization</param>
        public FileEventSubscriptions(FileEventStoreConfiguration configuration, ISerializer serializer)
        {
            _configuration = configuration;
            _serializer = serializer;
        }

#pragma warning disable 1591 // Xml Comments

        string GetPathForSubscriptions()
        {
            var fullPath = Path.Combine(_configuration.Path, "EventSubscribers");
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
            return fullPath;
        }

        public IEnumerable<EventSubscription> GetAll()
        {
            var subscriptions = new List<EventSubscription>();
            var path = GetPathForSubscriptions();
            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var json = File.ReadAllText(file);
                var subscription = _serializer.FromJson<EventSubscription>(json);
                subscriptions.Add(subscription);
            }

            return subscriptions;
        }

        public void Save(EventSubscription subscription)
        {
            var path = GetPathForSubscriptions();
            var file = string.Format("{0}\\{1}.{2}.{3}", path, subscription.Owner.Namespace, subscription.Owner.Name, subscription.EventName);
            var json = _serializer.ToJson(subscription);
            File.WriteAllText(file, json);
        }

        public void ResetLastEventForAllSubscriptions()
        {
            var path = GetPathForSubscriptions();
            Directory.Delete(path, true);
        }
#pragma warning restore 1591 // Xml Comments
    }
}
