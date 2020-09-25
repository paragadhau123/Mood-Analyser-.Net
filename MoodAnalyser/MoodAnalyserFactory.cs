//-----------------------------------------------------------------------
// <copyright file="MoodAnalyserFactory.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace MoodAnalyser
{
    using System;
    using System.Reflection;

    /// <summary>
    /// MoodAnalyzer Factory Class
    /// </summary>
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// Type object 
        /// </summary>
        public readonly Type TYPE = Type.GetType("MoodAnalyser.MoodAnalysermain");

        /// <summary>
        /// Method to validate first name
        /// </summary>
        /// <param name="className">total distance</param>
        /// <param name="mood">total time</param>
        /// <returns>return value</returns>
        public static dynamic ChangeTheMood(string className, string mood)
        {
            try
            {
                Type type = Type.GetType(className);
                dynamic change_mood = Activator.CreateInstance(type, mood);
                MethodInfo method = type.GetMethod("AnalyseMood");
                dynamic value = method.Invoke(change_mood, new object[] { mood });
                return value;
            }
            catch (Exception e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EnteredNull, e.Message);
            }
        }

        /// <summary>
        /// Method for set field
        /// </summary>
        /// <param name="message">total distance</param>
        /// <param name="fieldName">total distance</param>
        /// <returns>return message</returns>
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalysermain moodAnalysemain = new MoodAnalysermain();
                Type type = typeof(MoodAnalysermain);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                field.SetValue(moodAnalysemain, message);
                return moodAnalysemain.Message;
            }
            catch (Exception)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EnteredNull, "Message is never null");
            }
        }

        /// <summary>
        /// Method to validate first name
        /// </summary>
        /// <param name="noOfParameters">define type</param>
        /// <returns>return constructor</returns>
        public ConstructorInfo GetConstructor(int noOfParameters)
        {
            try
            {
                ConstructorInfo[] constructors = this.TYPE.GetConstructors();
                foreach (ConstructorInfo constructor in constructors)
                {
                    if (constructor.GetParameters().Length == noOfParameters)
                    {
                        return constructor;
                    }
                }

                return constructors[0];
            }
            catch (Exception)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ClassNotFound, "Class not found");
            }
        }

        /// <summary>
        /// method to  object using class name
        /// </summary>
        /// <param name="className"> class name</param>
        /// <returns> created Object </returns>
        public object CreateObjectUsingClass(string className)
        {
            try
            {
                Type type = Type.GetType(className); 
                object createdObject = Activator.CreateInstance(type);
                return createdObject;
            }
            catch (Exception)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ClassNotFound, "Class not found");
            }
        }

        /// <summary>
        /// Method to validate first name
        /// </summary>
        /// <param name="className">total distance</param>
        /// <param name="constructor">total time</param>
        /// <param name="noOfParameters">define type</param>
        /// <returns>return object</returns>
        public object CreateObjectUsingConstructor(string className, ConstructorInfo constructor, int noOfParameters)
        {
            try
            {
                Type type = Type.GetType(className);
                if (constructor != this.GetConstructor(noOfParameters))
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NoSuchMethod, "No Such Method exists");
                }

                object createdObject = constructor.Invoke(new object[0]);
                return createdObject;
            }
            catch (Exception)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ClassNotFound, "Class not found");
            }
        }

        /// <summary>
        /// Method to validate first name
        /// </summary>
        /// <param name="className">total distance</param>
        /// <param name="constructor">total time</param>
        /// <param name="parameterValue">define type</param>
        /// <returns>return object</returns>
        public object CreateObjectUsingParameterizedConstructor(string className, ConstructorInfo constructor, string parameterValue)
        {
            try
            {
                Type type = Type.GetType(className);
                if (className != type.FullName)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ClassNotFound, "No such class");
                }

                if (constructor != type.GetConstructors()[1])
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NoSuchMethod, "No such Method Found");
                }

                object object_return = Activator.CreateInstance(type, parameterValue);
                return object_return;
            }
            catch (Exception)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ClassNotFound, "Class not found");
            }
        }

        /// <summary>
        /// Method to validate first name
        /// </summary>
        /// <param name="methodName">total distance</param>
        /// <param name="parameter">total time</param>
        /// <returns>return object</returns>
        public dynamic InvokeMoodAnalyser(string methodName, object parameter)
        {
            try
            {
                if (methodName != "AnalyseMood1")
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NoSuchMethod, "Error ! Cannot invoke MoodAnalyser");
                }

                MethodInfo method = this.TYPE.GetMethod(methodName);
                object createdObject = Activator.CreateInstance(this.TYPE, parameter);
                method.Invoke(createdObject, null);
                return "Happy";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }     
    }
}
