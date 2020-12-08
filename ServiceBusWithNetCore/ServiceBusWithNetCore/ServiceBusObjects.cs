using Azure.Messaging.ServiceBus.Administration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusWithNetCore
{
    class ServiceBusObjects
    {
        public static async Task<QueueProperties> CreateQueueAsync(string connectionString, string queueName, bool requiresSession = false)
        {
            var client = new ServiceBusAdministrationClient(connectionString);
            var options = new CreateQueueOptions(queueName)
            {
                DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1),
                EnableBatchedOperations = true,
                DeadLetteringOnMessageExpiration = true,
                EnablePartitioning = false,
                ForwardDeadLetteredMessagesTo = null,
                ForwardTo = null,
                LockDuration = TimeSpan.FromSeconds(45),
                MaxDeliveryCount = 8,
                MaxSizeInMegabytes = 2048,
                UserMetadata = "some metadata"
            };
            options.RequiresSession = requiresSession;

            options.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
                "allClaims",
                new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

            return await client.CreateQueueAsync(options);
        }

        public static async Task<QueueProperties> GetQueueAsync(string connectionString, string queueName)
        {
            try
            {
                var client = new ServiceBusAdministrationClient(connectionString);
                return await client.GetQueueAsync(queueName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static async Task<QueueProperties> UpdateQueueAsync(string connectionString, QueueProperties queue)
        {
            var client = new ServiceBusAdministrationClient(connectionString);
            queue.UserMetadata = "other metadata";
            return await client.UpdateQueueAsync(queue);
        }
        public static async Task<Azure.Response> DeleteQueueAsync(string connectionString, string queueName)
        {
            var client = new ServiceBusAdministrationClient(connectionString);
            return await client.DeleteQueueAsync(queueName);
        }
        public static async Task<TopicProperties> CreateTopicAsync(string topicName, string connectionString)
        {
            var client = new ServiceBusAdministrationClient(connectionString);
            var topicOptions = new CreateTopicOptions(topicName)
            {
                DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1),
                EnableBatchedOperations = true,
                EnablePartitioning = false,
                MaxSizeInMegabytes = 2048,
                UserMetadata = "some metadata"
            };

            topicOptions.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
                "allClaims",
                new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

            return await client.CreateTopicAsync(topicOptions);
        }

        public static async Task<TopicProperties> GetTopicAsync(string topicName, string connectionString)
        {
            try
            {
                var client = new ServiceBusAdministrationClient(connectionString);
                return await client.GetTopicAsync(topicName);
            }
            catch (Exception ex)
            {
                return null;
            }          
        }

        public static async Task<TopicProperties> UpdateTopicAsync(TopicProperties topic, string connectionString)
        {
            var client = new ServiceBusAdministrationClient(connectionString);
            topic.UserMetadata = "other metadata";
            return await client.UpdateTopicAsync(topic);
        }
        public static async Task<Azure.Response> DeleteTopicAsync(string topicName, string connectionString)
        {
            var client = new ServiceBusAdministrationClient(connectionString);
            return await client.DeleteTopicAsync(topicName);
        }

        public static async Task<SubscriptionProperties> CreateSubscriptionAsync(string topicName, string connectionString, string subscriptionName)
        {
            var client = new ServiceBusAdministrationClient(connectionString);

            var subscriptionOptions = new CreateSubscriptionOptions(topicName, subscriptionName)
            {
                DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                EnableBatchedOperations = true,
                UserMetadata = "some metadata"
            };
            return await client.CreateSubscriptionAsync(subscriptionOptions);
        }

        public static async Task<SubscriptionProperties> GetSubscriptionAsync(string topicName, string connectionString, string subscriptionName)
        {
            try
            {
                var client = new ServiceBusAdministrationClient(connectionString);
                return await client.GetSubscriptionAsync(topicName, subscriptionName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static async Task<SubscriptionProperties> UpdateSubscriptionAsync(string connectionString, SubscriptionProperties subscription)
        {
            var client = new ServiceBusAdministrationClient(connectionString);
            subscription.UserMetadata = "other metadata";
            return await client.UpdateSubscriptionAsync(subscription);
        }
        public static async Task<Azure.Response> DeleteSubscriptionAsync(string topicName, string connectionString, string subscriptionName)
        {
            var client = new ServiceBusAdministrationClient(connectionString);
            return await client.DeleteSubscriptionAsync(topicName, subscriptionName);
        }

    }
}
