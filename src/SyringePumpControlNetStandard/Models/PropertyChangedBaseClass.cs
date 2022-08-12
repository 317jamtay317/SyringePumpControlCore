using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SyringePumpControlNetStandard.Annotations;

namespace SyringePumpControlNetStandard.Models
{
    public abstract class PropertyChangedBaseClass:INotifyPropertyChanged
    {
        private Dictionary<string, object> _values = new Dictionary<string, object>();

        /// <summary>
        /// Get the Property Value
        /// </summary>
        /// <param name="propertyName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            T t = default;
            
            if (_values.ContainsKey(propertyName))
            {
                //we can safely case here as if the property name is 
                //in the dictionary we know that it exists and has to be that 
                //type. if it isn't that type we should throw a cast exception
                t = (T)_values[propertyName];
            }

            return t;
        }

        /// <summary>
        /// Sets the property and calls OnPropertyChanged
        /// </summary>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <typeparam name="T"></typeparam>
        protected virtual void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (_values.ContainsKey(propertyName))
            {
                _values[propertyName] = value;
            }
            else
            {
                _values.Add(propertyName, value);
            }
            OnPropertyChanged(propertyName);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}