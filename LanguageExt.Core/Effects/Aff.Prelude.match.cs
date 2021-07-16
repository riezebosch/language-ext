using System;
using LanguageExt.Common;
using LanguageExt.Effects.Traits;

namespace LanguageExt
{
    public static partial class Prelude
    {
        /// <summary>
        /// Catch an error if the predicate matches
        /// </summary>
        public static AffCatch<RT, A> matchError<RT, A>(Func<Error, bool> predicate, Func<Error, Aff<RT, A>> Fail) where RT : struct, HasCancel<RT> =>
            new AffCatch<RT, A>(predicate, Fail);
        
        /// <summary>
        /// Catch an error if the predicate matches
        /// </summary>
        public static AffCatch<A> matchError<A>(Func<Error, bool> predicate, Func<Error, Aff<A>> Fail) =>
            new AffCatch<A>(predicate, Fail);

        
               
        /// <summary>
        /// Catch an error if the error matches the argument provided 
        /// </summary>
        public static AffCatch<RT, A> match<RT, A>(Error error, Func<Error, Aff<RT, A>> Fail) where RT : struct, HasCancel<RT> =>
            matchError(e => e == error, Fail);
        
        /// <summary>
        /// Catch an error if the error matches the argument provided 
        /// </summary>
        public static AffCatch<A> match<A>(Error error, Func<Error, Aff<A>> Fail) =>
            matchError(e => e == error, Fail);
        
        /// <summary>
        /// Catch an error if the error matches the argument provided 
        /// </summary>
        public static AffCatch<RT, A> match<RT, A>(Error error, Aff<RT, A> Fail) where RT : struct, HasCancel<RT> =>
            matchError(e => e == error, _ => Fail);
        
        /// <summary>
        /// Catch an error if the error matches the argument provided 
        /// </summary>
        public static AffCatch<A> match<A>(Error error, Aff<A> Fail) =>
            matchError(e => e == error, _ => Fail);

        
        /// <summary>
        /// Catch an error if the error `Code` matches the `errorCode` argument provided 
        /// </summary>
        public static AffCatch<RT, A> match<RT, A>(int errorCode, Func<Error, Aff<RT, A>> Fail) where RT : struct, HasCancel<RT> =>
            matchError(e => e.Code == errorCode, Fail);
        
        /// <summary>
        /// Catch an error if the error `Code` matches the `errorCode` argument provided 
        /// </summary>
        public static AffCatch<A> match<A>(int errorCode, Func<Error, Aff<A>> Fail) =>
            matchError(e => e.Code == errorCode, Fail);
        
        /// <summary>
        /// Catch an error if the error message matches the `errorText` argument provided 
        /// </summary>
        public static AffCatch<RT, A> match<RT, A>(string errorText, Aff<RT, A> Fail) where RT : struct, HasCancel<RT> =>
            matchError(e => e.Message == errorText, _ => Fail);
        
        /// <summary>
        /// Catch an error if the error message matches the `errorText` argument provided 
        /// </summary>
        public static AffCatch<A> match<A>(string errorText, Aff<A> Fail) =>
            matchError(e => e.Message == errorText, _ => Fail);
        
        /// <summary>
        /// Catch an error if the error `Code` matches the `errorCode` argument provided 
        /// </summary>
        public static AffCatch<RT, A> match<RT, A>(int errorCode, Aff<RT, A> Fail) where RT : struct, HasCancel<RT> =>
            matchError(e => e.Code == errorCode, _ => Fail);
        
        /// <summary>
        /// Catch an error if the error `Code` matches the `errorCode` argument provided 
        /// </summary>
        public static AffCatch<A> match<A>(int errorCode, Aff<A> Fail) =>
            matchError(e => e.Code == errorCode, _ => Fail);

                
        /// <summary>
        /// Catch an error if the error message matches the `errorText` argument provided 
        /// </summary>
        public static AffCatch<RT, A> match<RT, A>(string errorText, Func<Error, Aff<RT, A>> Fail) where RT : struct, HasCancel<RT> =>
            matchError(e => e.Message == errorText, Fail);
        
        /// <summary>
        /// Catch an error if the error message matches the `errorText` argument provided 
        /// </summary>
        public static AffCatch<A> match<A>(string errorText, Func<Error, Aff<A>> Fail) =>
            matchError(e => e.Message == errorText, Fail);

        
        /// <summary>
        /// Catch an error if it's of a specific exception type
        /// </summary>
        public static AffCatch<A> match<A>(Func<Exception, bool> predicate, Func<Exception, Aff<A>> Fail) =>
            matchError(e => e.Exception.Map(predicate).IfNone(false), e => Fail(e));

        /// <summary>
        /// Catch an error if it's of a specific exception type
        /// </summary>
        public static AffCatch<A> match<A>(Func<Exception, bool> predicate, Aff<A> Fail) =>
            matchError(e => e.Exception.Map(predicate).IfNone(false), e => Fail);

        /// <summary>
        /// Catch an error if it's of a specific exception type
        /// </summary>
        public static AffCatch<RT, A> match<RT, A>(Func<Exception, bool> predicate, Func<Exception, Aff<RT, A>> Fail) where RT : struct, HasCancel<RT> =>
            matchError(e => e.Exception.Map(predicate).IfNone(false), e => Fail(e));

        /// <summary>
        /// Catch an error if it's of a specific exception type
        /// </summary>
        public static AffCatch<RT, A> match<RT, A>(Func<Exception, bool> predicate, Aff<RT, A> Fail) where RT : struct, HasCancel<RT> =>
            matchError(e => e.Exception.Map(predicate).IfNone(false), e => Fail);
    }
}
