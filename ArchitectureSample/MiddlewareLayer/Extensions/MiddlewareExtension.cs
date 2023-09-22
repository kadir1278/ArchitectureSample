﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MiddlewareLayer.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareLayer.Extensions
{
    public static class MiddlewareExtension
    {
        #region Constructor
        private static IConfigurationRoot _configurationRoot;
        private static IConfigurationRoot configurationRoot
        {
            get
            {
                string jsonFile = "MiddlewareSettings.json";

                if (_configurationRoot == null)
                    _configurationRoot = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile(jsonFile)
                        .Build();

                return _configurationRoot;
            }
        }
        #endregion

        public static IApplicationBuilder GlobalFilter(this IApplicationBuilder applicationBuilder)
        {
            MiddlewareSettings middlewareSettings = configurationRoot.Get<MiddlewareSettings>();

            if (middlewareSettings.HostFilterStatus)
                applicationBuilder.UseMiddleware<HostFilterMiddleware>();


            return applicationBuilder;
        }
    }
}
