﻿using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using GuardNet;

namespace Invictus.Testing
{
    /// <summary>
    /// Thrown when a problem occurs during interaction with a logic app running in Azure.
    /// </summary>
    [Serializable]
    public class LogicAppException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogicAppException"/> class.
        /// </summary>
        public LogicAppException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicAppException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the exception.</param>
        public LogicAppException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicAppException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public LogicAppException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicAppException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the exception.</param>
        /// <param name="logicAppName">The name of the logic app resource running in Azure.</param>
        /// <param name="resourceGroup">The resource group where the logic app is located.</param>
        /// <param name="subscriptionId">The ID that identifies the subscription on Azure.</param>
        public LogicAppException(
            string message,
            string logicAppName,
            string resourceGroup,
            string subscriptionId) : base(message)
        {
            Guard.NotNullOrWhitespace(logicAppName, nameof(logicAppName));
            Guard.NotNullOrWhitespace(resourceGroup, nameof(resourceGroup));
            Guard.NotNullOrWhitespace(subscriptionId, nameof(subscriptionId));

            LogicAppName = logicAppName;
            ResourceGroup = resourceGroup;
            SubscriptionId = subscriptionId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicAppException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the exception.</param>
        /// <param name="logicAppName">The name of the logic app resource running in Azure.</param>
        /// <param name="resourceGroup">The resource group where the logic app is located.</param>
        /// <param name="subscriptionId">The ID that identifies the subscription on Azure.</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public LogicAppException(
            string message,
            string logicAppName,
            string resourceGroup,
            string subscriptionId,
            Exception innerException) : base(message, innerException)
        {
            Guard.NotNullOrWhitespace(logicAppName, nameof(logicAppName));
            Guard.NotNullOrWhitespace(resourceGroup, nameof(resourceGroup));
            Guard.NotNullOrWhitespace(subscriptionId, nameof(subscriptionId));

            LogicAppName = logicAppName;
            ResourceGroup = resourceGroup;
            SubscriptionId = subscriptionId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicAppException"/> class.
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected LogicAppException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            string logicAppName = info.GetString(nameof(LogicAppName));
            string resourceGroup = info.GetString(nameof(ResourceGroup));
            string subscriptionId = info.GetString(nameof(SubscriptionId));

            Guard.NotNullOrWhitespace(logicAppName, nameof(logicAppName));
            Guard.NotNullOrWhitespace(resourceGroup, nameof(resourceGroup));
            Guard.NotNullOrWhitespace(subscriptionId, nameof(subscriptionId));

            LogicAppName = logicAppName;
            ResourceGroup = resourceGroup;
            SubscriptionId = subscriptionId;
        }

        /// <summary>
        /// Gets the name of the logic app running on Azure.
        /// </summary>
        public string LogicAppName { get; }

        /// <summary>
        /// Gets the resource group on Azure in which the logic app is located.
        /// </summary>
        public string ResourceGroup { get; }

        /// <summary>
        /// Gets the ID of the subscription of
        /// </summary>
        public string SubscriptionId { get; }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info">info</paramref> parameter is a null reference (Nothing in Visual Basic).</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Guard.NotNull(info, nameof(info));

            info.AddValue(nameof(LogicAppName), LogicAppName);
            info.AddValue(nameof(ResourceGroup), ResourceGroup);
            info.AddValue(nameof(SubscriptionId), SubscriptionId);

            base.GetObjectData(info, context);
        }
    }
}
