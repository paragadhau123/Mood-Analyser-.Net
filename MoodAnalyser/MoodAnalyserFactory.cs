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
            catch (Exception e)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.ClassNotFound, "Class not found");
            }
        }
       
        public object CreateObjectUsingParameterizedConstructor(string className, ConstructorInfo constructor, string parameterValue)
        {
            try
            {
                Type type = Type.GetType(className);
                if (className != type.Name)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.ClassNotFound, "No such class");
                }
                if (constructor != type.GetConstructors()[1])
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NoSuchMethod, "No such Method Found");
                }
                Object Object_return = Activator.CreateInstance(type, parameterValue);
                return Object_return;
            }
            catch (Exception e)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.ClassNotFound, "Class not found");
            }
        }
        public dynamic InvokeMoodAnalyser(string methodName,object parameter)
        {
            try
            {

                if (methodName != "AnalyseMood")
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NoSuchMethod, "Error ! Cannot invoke MoodAnalyser");
                }
                MethodInfo method = type.GetMethod(methodName);
                object createdObject = Activator.CreateInstance(type, parameter);
                method.Invoke(createdObject, null);
                return "Happy";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public static dynamic ChangeTheMood(string className, string mood)
        {
            try
            {
                Type type = Type.GetType(className);
                dynamic change_mood = Activator.CreateInstance(type, mood);
                MethodInfo method = type.GetMethod("getMood");
                dynamic value = method.Invoke(change_mood, new object[] { mood });
                return value;
            }
            catch (Exception e)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.EnteredNull, e.Message);
            }
        }
    }
}
