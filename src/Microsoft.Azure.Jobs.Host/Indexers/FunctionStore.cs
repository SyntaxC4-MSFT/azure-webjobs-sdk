﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Azure.Jobs.Internals
{
    internal class FunctionStore : IFunctionTableLookup
    {
        private IndexInMemory _store;

        // storageConnectionString - the account that the functions will bind against. 
        // Index all methods in the types provided by the locator
        public FunctionStore(string storageConnectionString, string serviceBusConnectionString, IConfiguration config, IEnumerable<Type> types)
        {
            var indexer = Init(storageConnectionString, config);
            foreach (Type t in types)
            {
                indexer.IndexType(m => OnApplyLocationInfo(storageConnectionString, serviceBusConnectionString, m),t, storageConnectionString, serviceBusConnectionString);
            }
        }
        
        private Indexer Init(string storageConnectionString, IConfiguration config)
        {
            _store = new IndexInMemory();
            return new Indexer(_store, config.NameResolver, config);
        }

        private FunctionLocation OnApplyLocationInfo(string accountConnectionString, string serviceBusConnectionString, MethodInfo method)
        {
            var loc = new MethodInfoFunctionLocation(method)
            {
                StorageConnectionString = accountConnectionString,
                ServiceBusConnectionString = serviceBusConnectionString
            };

            return loc;
        }

        public FunctionDefinition Lookup(string functionId)
        {
            IFunctionTableLookup x = _store;
            return x.Lookup(functionId);
        }

        public FunctionDefinition[] ReadAll()
        {
            IFunctionTableLookup x = _store;
            return x.ReadAll();
        }
    }
}