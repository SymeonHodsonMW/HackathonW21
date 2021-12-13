using ElmerFudd.Services;
using MassTransit;
using MassTransit.MultiBus;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElmerFudd.Extensions {
    public static class ConfigureMassTransitExtension {
        public static void ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration) {
            // Configure IBusControl
            services.AddMassTransit<IDemoMessageBusControl>(x => {
                x.UsingRabbitMq((context, cfg) => {
                    ConfigMassTransit(cfg, configuration);
                });
            });

            services.AddMassTransitHostedService();
        }

        private static void ConfigMassTransit(IRabbitMqBusFactoryConfigurator cfg, IConfiguration configuration) {
            IConfigurationSection cofigSection = configuration.GetSection("MassTransit");

            cfg.Host(new Uri(cofigSection.GetValue<string>($"RabbitMq_VirtualHost_Messages")),
            h => {
                h.Username(cofigSection.GetValue<string>("RabbitMq_User"));
                h.Password(cofigSection.GetValue<string>("RabbitMq_Password"));
            });
        }
    }
}