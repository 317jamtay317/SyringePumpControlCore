using System;
using System.ComponentModel;
using SyringePumpControlNetStandard.Models.Commands;

namespace SyringePumpControlNetStandard.Models
{
    public interface IPump:INotifyPropertyChanged
    {
        /// <summary>
        /// if the port is open we are connected
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// The Pump address range between 00 and 99
        /// </summary>
        int Address { get; set; }

        /// <summary>
        /// The direction of the pump, by default the direction is infuse
        /// </summary>
        PumpDirection PumpDirection { get; }

        string Direction { get; }

        /// <summary>
        /// the diameter of the syringe
        /// </summary>
        float Diameter { get; set; }

        /// <summary>
        /// the rate the the pump flows 
        /// </summary>
        float Rate { get; set; }

        /// <summary>
        /// Units while pump is flowing, default is uL/min
        /// </summary>
        RateUnits RateUnits { get; set; }

        /// <summary>
        /// Parsed RateUnits string
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        string UnitRate { get; }
        
        Volume TargetVolume { get; set; }
        
        /// <summary>
        /// Connect to the pump
        /// </summary>
        void Connect();
        
        /// <summary>
        /// Disconnect from the pump
        /// </summary>
        void Disconnect();
        
        /// <summary>
        /// Send your request
        /// </summary>
        /// <param name="pumpCommand"></param>
        void Send(IPumpCommand pumpCommand);

        /// <summary>
        /// Updates the values of the pump
        /// </summary>
        /// <param name="values"></param>
        void UpdateValues(PumpValues values);
    }
}