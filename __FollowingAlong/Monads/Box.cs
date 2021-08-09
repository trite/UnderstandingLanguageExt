using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace __FollowingAlong.Monads
{
    /// <summary>
    /// A box can hold a thing only
    /// </summary>
    /// <typeparam name="T">The type of the thing</typeparam>
    public class Box<T>
    {
        public Box(T newItem)
        {
            Item = newItem;
            IsEmpty = false;
        }

        public Box() { }

        private T _item;

        public T Item
        {
            get => _item;
            set
            {
                _item = value;
                IsEmpty = false;
            }
        }
        
        public bool IsEmpty = true;
    }

    public static class BoxMethods
    {
        /// <summary>
        /// Transforms the contents of a Box, in a user defined way
        /// </summary>
        /// <typeparam name="TA">The type of the thing in the box to start with</typeparam>
        /// <typeparam name="TB">The result type that the transforming function to transform to</typeparam>
        /// <param name="box">The Box that the extension method will work on</param>
        /// <param name="map">User defined way to transform the contents of the box</param>
        /// <returns>The results of the transformation, put back into a box</returns>
        public static Box<TB> Select<TA, TB>(this Box<TA> box, Func<TA, TB> map)
        {
            // Validate/Check if box is valid(not empty) and if so, run the transformation function on it, otherwise don't
            if (box.IsEmpty)
            {
                // No, return the empty box
                return new Box<TB>();
            }
            
            // Extract the item from the Box and run the provided transform function ie run the map() function
            // ie map is the name of the transformation function the user provided.
            TB transformedItem = map(box.Item);

            return new Box<TB>(transformedItem);
        }

        /// <summary>
        /// Validate, Extract, Transform and Lift (If Valid)
        /// Check/Validate then transform to T and lift into Box<T>
        /// </summary>
        public static Box<TB> Bind<TA, TB>(this Box<TA> box, Func<TA, Box<TB>> bind /*liftAndTransform*/)
        {
            // Validate
            if (box.IsEmpty)
                return new Box<TB>();

            //Extract 
            TA extract = box.Item;

            // Transform and the user-defined function (notice that its up to the user defined function to 'lift' any result of the transformation into a new Box)
            Box<TB> transformedAndLifted = bind(extract); //  should return its results of its transformation in a Box 

            return transformedAndLifted;
        }

        /// <summary>
        /// Validate, Extract, Transform and automatic Lift (If Valid) 
        /// </summary>
        public static Box<TB> Map<TA, TB>(this Box<TA> box, Func<TA, TB> select /*Transform*/)
        {
            // Validate
            if (box.IsEmpty)
                return new Box<TB>();

            // Extract
            TA extract = box.Item;

            // Transform
            TB transformed = select(extract); // user provided function does not need to 'lift' its result into a Box like Bind() requires 

            // Lift
            return new Box<TB>(transformed);
        }
    }

}
