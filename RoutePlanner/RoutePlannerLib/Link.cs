﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public enum TransportModes { Ship, Rail, Flight, Car, Bus, Tram };

    /// <summary>
    /// Represents a link between two cities with its distance
    /// </summary>
    public class Link : IComparable
    {
        private City fromCity;
        private City toCity;
        double distance;

        TransportModes transportMode = TransportModes.Car;

        public TransportModes TransportMode
        {
            get { return transportMode; }
        }

        public City FromCity
        {
            get { return fromCity; }
        }

        public City ToCity
        {
            get { return toCity; }
        }

        public Link(City fromCity, City toCity, double distance)
        {
            this.fromCity = fromCity;
            this.toCity = toCity;
            this.distance = distance;
        }

        public Link(City fromCity, City toCity, double distance, TransportModes transportMode)
            : this(fromCity, toCity, distance)
        {
            this.transportMode = transportMode;
        }

        public double Distance
        {
            get { return distance; }
        }

        /// <summary>
        /// Specifies "distance" as default compare criteria 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public int CompareTo(object o)
        {
            var other = (Link)o;
            return (int)(1000 * (distance - other.distance));
        }

        /// <summary>
        /// checks if both cities of the link are included in the passed city list
        /// </summary>
        /// <param name="cities">list of city objects</param>
        /// <returns>true if both link-cities are in the list</returns>
        /*internal bool IsIncludedIn(List<City> cities)
        {
            var included = cities.Any(c => c.Name == FromCity.Name || c.Name == ToCity.Name);
            return included;
        }*/

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof (Link))
            {
                var comp = (Link) obj;
                return fromCity.Equals(comp.FromCity) && toCity.Equals(comp.toCity) && distance.Equals(comp.Distance);
            }
            return false;
        }

        ///<summary>
        ///Lab 9: Schritt 2checks if both cities of the link are included in the passed city list
        ///</summary>
        ///<param name="cities">list of city objects</param>
        ///<returns>true if both link-cities are in the list</returns>
        internal bool IsIncludedIn(List<City> cities)
        {
            var foundFrom = false;
            var foundTo = false;

            foreach (var c in cities)
            {
                if (!foundFrom && c.Name == FromCity.Name)
                {
                    foundFrom = true;
                }
                if (!foundTo && c.Name == ToCity.Name)
                {
                    foundTo = true;
                }
                if (foundTo && foundFrom)
                    return true;
            }
                return false;
        }

    }
}
