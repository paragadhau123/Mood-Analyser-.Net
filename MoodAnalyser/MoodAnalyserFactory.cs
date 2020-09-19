using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoodAnalyser
{
    class MoodAnalyserFactory
    {

        /// <summary>
        /// getting type of required class
        /// </summary>
        Type type = typeof(MoodAnalysermain);

        /// <summary>
        /// method to get constructor information of Type type and return the required constructor , default or parameterized
        /// </summary>
        /// <param name="noOfParameters"> no of paramters in constructor </param>
        /// <returns></returns>
        public ConstructorInfo GetConstructor(int noOfParameters = 0)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                if (constructor.GetParameters().Length == noOfParameters)
                    return constructor;
            }
            return constructors[0];
        }

        public object CreateObject(string className, ConstructorInfo constructor)
        {
            try
            {
                if (className != type.Name)
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.ClassNotFound, "Class does not exist");

                object createdObject = Activator.CreateInstance(className, type.Name);
                return createdObject;
            }
            catch (MoodAnalysisException exception)
            {
                return exception.Message;
            }
        }
    }
}
