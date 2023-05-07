﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace Persistence.Services.LanguageService;

        /// <summary>
        /// Dummy class to group shared resources
        /// </summary>
        public class SharedResource
        {
        }

        public class LanguageService
        {
            private readonly IStringLocalizer _localizer;

            public LanguageService(IStringLocalizerFactory factory)
            {
                var type = typeof(SharedResource);
                var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                _localizer = factory.Create("SharedResource", assemblyName.Name);
            }

            public LocalizedString Getkey(string key)
            {
                return _localizer[key];
            }
        }



