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
        readonly Type type = Type.GetType("MoodAnalyser.MoodAnalyser");

        /// <summary>
        /// method to get constructor information of Type type and return the required constructor , default or parameterized
        /// </summary>
        /// <param name="noOfParameters"> no of paramters in constructor </param>
        /// <returns></returns>
        public ConstructorInfo GetConstructor(int noOfParameters)
        {
            try
            {
                ConstructorInfo[] constructors = type.GetConstructors();
                foreach (ConstructorInfo constructor in constructors)
                {
                    if (constructor.GetParameters().Length == noOfParameters)
                        return constructor;
                }
                return constructors[0];
            }
            catch (Exception) { 
             throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.ClassNotFound, "Class not found");
            }
        }
        /// <summary>
        /// method to instanciate object using class name
        /// </summary>
        /// <param name="className"> class name</param>
        /// <returns> instance </returns>
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
        /// <summary>
        /// method to instanciate object using paramterized constructor
        /// </summary>
        /// <param name="class_name"></param>
        /// <param name="constructor"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public object CreateObjectUsingParameterizedConstructor(string class_name, ConstructorInfo constructor, string parameterValue)
        {
            try
            {
                // given class not equals to type name throw exception
                if (class_name != type.Name)
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.ClassNotFound ,"No such class");
                // given constructor name is not equals to constructor of type throw exception
                if (constructor != type.GetConstructors()[1])
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NoSuchMethod ,"No such Method Found");
                // create instance with constructor
                //var Object_return = constructor.Invoke(); 
                //creating instance using parametersised constructor
                Object Object_return = Activator.CreateInstance(type, parameterValue);
                return Object_return;
            }
            catch (Exception ) { return null; }
        }
    }
}
