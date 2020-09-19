using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {

        /// <summary>
        /// getting type of required class
        /// </summary>
        Type type = Type.GetType("MoodAnalyser.MoodAnalyser");

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

        public object CreateObjectUsingClass(string className)
        {
            try
            {
                if (className != type.Name)
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.ClassNotFound, "No Such class exists");

                object createdObject = Activator.CreateInstance(className, type.FullName);
                return createdObject;
            }
            catch (MoodAnalysisException exception)
            {
                return exception.Message;
            }
        }
        public object CreateObjectUsingConstructor(ConstructorInfo constructor, int noOfParameters)
        {
            try
            {
                if (constructor != GetConstructor(noOfParameters))
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NoSuchMethod, "No Such Method exists");

                object createdObject = constructor.Invoke(new object[0]);
                return createdObject;
            }
            catch (MoodAnalysisException exception)
            {
                return exception.Message;
            }
        }
    }
}
