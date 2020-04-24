﻿using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;
using LanguageExt.DataTypes.Serialisation;

namespace Tutorial14
{
    // This tutorial shows you what a what an Either<> type is and how to use it generally
    
    class Program
    {
        static void Main(string[] args)
        {
            string word = "five";

            // Note: We're creating an either with the left type as int and the right type as string.
            // You can assign either type to an either
            Either<int, string> amount = 5;
            amount = word;
            var emptyEither = new Either<int, string>();
            
            // Note you can do the same transformations you did on a Box<T> on an Either because it too is a Monad and it too has a Bind(), Map(), Select() and SelectMany() extension method.
            // This transformation occurs on the right hand value, provided that the either contains the right hand value and not the left (this is the inbuilt validation or short-circuiting Monad idea in action)
            
            var resultA = amount.Bind(str => TransformRight(str)); // Extract EitherData from either once validated ie that its not a right value, run transform function. 

            amount = 25;

            // notice that it's biased to its right value and only cares about running a transform on a right type.
            // The validation within Either's Bind() will check for a Right Type and then run the provided transform, if its left it will return what it has (25) but no transform will occur
            var resultB = amount.Bind(integer => TransformRight(integer)); // Wont run transformation because the validation will fail because its a left type.
            
            Console.WriteLine($"The value of resulta is '{resultA}' and the result of result b is '{resultB}' and an empty either looks like this '{emptyEither}' ");

            // notice how Either's bind function will extract the right part, if validation succeeds and runs the transformation as expected.
            Either<int, string> TransformRight(string extractedRight)
            {
                Either<int, string> result = extractedRight.ToUpper(); // Like all Bind functions we need to lift the result into the monad ie Either type
                return result;
            }

        }
        
    }      
}
