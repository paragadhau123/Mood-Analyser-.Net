using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
      
        Type type = Type.GetType("MoodAnalyser.MoodAnalysermain");

        
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
       
        public object CreateObjectUsingClass(string className)
        {
            try
            {
                Type type = Type.GetType(className); 
                object createdObject = Activator.CreateInstance(type);
                return createdObject;
            }
            catch (Exception e)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.ClassNotFound, "Class not found");
            }
        }
       
        public object CreateObjectUsingConstructor(String className,ConstructorInfo constructor, int noOfParameters)
        {
            try
            {
                Type type = Type.GetType(className);
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
       
        public object CreateObjectUsingParameterizedConstructor(string class_name, ConstructorInfo constructor, string parameterValue)
        {
            try
            {
               
                if (class_name != type.Name)
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.ClassNotFound ,"No such class");
              
                if (constructor != type.GetConstructors()[1])
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NoSuchMethod ,"No such Method Found");
               
                Object Object_return = Activator.CreateInstance(type, parameterValue);
                return Object_return;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public dynamic InvokeMoodAnalyser(object parameter)
        {
            try
            {

                MethodInfo method = type.GetMethod("AnalyseMood");
                object createdObject = Activator.CreateInstance(type, parameter);
                method.Invoke(createdObject, null);
                return "Happy";
            }
            catch (MoodAnalysisException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NoSuchMethod, "Error ! Cannot invoke MoodAnalyser");
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }
}
