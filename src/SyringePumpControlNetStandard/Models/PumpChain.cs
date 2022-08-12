using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace SyringePumpControlNetStandard.Models
{
    public class PumpChain:IEnumerable<IPump>
    {
        public PumpChain()
        {
            _dictionary = new ConcurrentDictionary<int, IPump>();
        }

        public PumpChain(IEnumerable<IPump> pumps):this()
        {
            AddRange(pumps);
        }

        private ConcurrentDictionary<int, IPump> _dictionary;


        public int TotalPumpsInChain => _dictionary.Count;
        
        public IPump this[int pumpAddress]
        {
            get => _dictionary[pumpAddress];
            set => _dictionary[pumpAddress] = value;
        }

        public PumpChain Add(IPump pump)
        {
            if (_dictionary.ContainsKey(pump.Address))
            {
                throw new ArgumentException($"The Address {pump.Address} already exists in the chain");
            }
            _dictionary.GetOrAdd(pump.Address, pump);
            return this;
        }

        public PumpChain AddRange(IEnumerable<IPump> pumps)
        {
            foreach (var pump in pumps)
            {
                Add(pump);
            }

            return this;
        }

        public PumpChain Remove(int pumpAddress)
        {
            if (_dictionary.ContainsKey(pumpAddress))
            {
                _dictionary.TryRemove(pumpAddress, out var p);
            }
            return this;
        }

        public bool ContainsPump(int pumpAddress)
        {
            return _dictionary.ContainsKey(pumpAddress);
        }

        public IPump GetPump(int pumpAddress)
        {
            _dictionary.TryGetValue(pumpAddress, out var pump);
            return pump;
        }
    
        #region IEnumerable

        public IEnumerator<IPump> GetEnumerator()
        {
            return _dictionary.Select(x => x.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}