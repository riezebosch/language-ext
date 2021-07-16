using System;
using LanguageExt.Common;

namespace LanguageExt
{
    public static partial class Prelude
    {
        /// <summary>
        /// Catch an error if the predicate matches
        /// </summary>
        public static EffCatch<RT, A> matchError<RT, A>(Func<Error, bool> predicate, Func<Error, Eff<RT, A>> Fail) =>
            new EffCatch<RT, A>(predicate, Fail);
        
        /// <summary>
        /// Catch an error if the predicate matches
        /// </summary>
        public static EffCatch<A> matchError<A>(Func<Error, bool> predicate, Func<Error, Eff<A>> Fail) =>
            new EffCatch<A>(predicate, Fail);

        /// <summary>
        /// Catch an error if the predicate matches
        /// </summary>
        public static EffCatch<A> matchError<A>(Func<Error, bool> predicate, Func<Error, A> Fail) =>
            matchError(predicate, e => SuccessEff(Fail(e)));

        /// <summary>
        /// Catch an error if the predicate matches
        /// </summary>
        public static EffCatch<A> matchError<A>(Func<Error, bool> predicate, A Fail) =>
            matchError(predicate, e => SuccessEff(Fail));
        
       
        /// <summary>
        /// Catch an error if the error matches the argument provided 
        /// </summary>
        public static EffCatch<RT, A> match<RT, A>(Error error, Func<Error, Eff<RT, A>> Fail) =>
            matchError(e => e == error, Fail);
        
        /// <summary>
        /// Catch an error if the error matches the argument provided 
        /// </summary>
        public static EffCatch<A> match<A>(Error error, Func<Error, Eff<A>> Fail) =>
            matchError(e => e == error, Fail);
        
        /// <summary>
        /// Catch an error if the error matches the argument provided 
        /// </summary>
        public static EffCatch<RT, A> match<RT, A>(Error error, Eff<RT, A> Fail) =>
            matchError(e => e == error, _ => Fail);
        
        /// <summary>
        /// Catch an error if the error matches the argument provided 
        /// </summary>
        public static EffCatch<A> match<A>(Error error, Eff<A> Fail) =>
            matchError(e => e == error, _ => Fail);
        
        /// <summary>
        /// Catch an error if the error matches the argument provided 
        /// </summary>
        public static EffCatch<A> match<A>(Error error, Func<Error, A> Fail) =>
            matchError(e => e == error, e => SuccessEff(Fail(e)));
        
        /// <summary>
        /// Catch an error if the error matches the argument provided 
        /// </summary>
        public static EffCatch<A> match<A>(Error error, A Fail) =>
            matchError(e => e == error, e => SuccessEff(Fail));        

        
        /// <summary>
        /// Catch an error if the error `Code` matches the `errorCode` argument provided 
        /// </summary>
        public static EffCatch<RT, A> match<RT, A>(int errorCode, Func<Error, Eff<RT, A>> Fail) =>
            matchError(e => e.Code == errorCode, Fail);
        
        /// <summary>
        /// Catch an error if the error `Code` matches the `errorCode` argument provided 
        /// </summary>
        public static EffCatch<A> match<A>(int errorCode, Func<Error, Eff<A>> Fail) =>
            matchError(e => e.Code == errorCode, Fail);
        
        /// <summary>
        /// Catch an error if the error `Code` matches the `errorCode` argument provided 
        /// </summary>
        public static EffCatch<RT, A> match<RT, A>(int errorCode, Eff<RT, A> Fail) =>
            matchError(e => e.Code == errorCode, _ => Fail);
        
        /// <summary>
        /// Catch an error if the error `Code` matches the `errorCode` argument provided 
        /// </summary>
        public static EffCatch<A> match<A>(int errorCode, Eff<A> Fail) =>
            matchError(e => e.Code == errorCode, _ => Fail);
        
        /// <summary>
        /// Catch an error if the error `Code` matches the `errorCode` argument provided 
        /// </summary>
        public static EffCatch<A> match<A>(int errorCode, Func<Error, A> Fail) =>
            matchError(e => e.Code == errorCode, e => SuccessEff(Fail(e)));
        
        /// <summary>
        /// Catch an error if the error `Code` matches the `errorCode` argument provided 
        /// </summary>
        public static EffCatch<A> match<A>(int errorCode, A Fail) =>
            matchError(e => e.Code == errorCode, e => SuccessEff(Fail));

                
        /// <summary>
        /// Catch an error if the error message matches the `errorText` argument provided 
        /// </summary>
        public static EffCatch<RT, A> match<RT, A>(string errorText, Func<Error, Eff<RT, A>> Fail) =>
            matchError(e => e.Message == errorText, Fail);
        
        /// <summary>
        /// Catch an error if the error message matches the `errorText` argument provided 
        /// </summary>
        public static EffCatch<A> match<A>(string errorText, Func<Error, Eff<A>> Fail) =>
            matchError(e => e.Message == errorText, Fail);
        
        /// <summary>
        /// Catch an error if the error message matches the `errorText` argument provided 
        /// </summary>
        public static EffCatch<RT, A> match<RT, A>(string errorText, Eff<RT, A> Fail) =>
            matchError(e => e.Message == errorText, _ => Fail);
        
        /// <summary>
        /// Catch an error if the error message matches the `errorText` argument provided 
        /// </summary>
        public static EffCatch<A> match<A>(string errorText, Eff<A> Fail) =>
            matchError(e => e.Message == errorText, _ => Fail);
        
        /// <summary>
        /// Catch an error if the error message matches the `errorText` argument provided 
        /// </summary>
        public static EffCatch<A> match<A>(string errorText, Func<Error, A> Fail) =>
            match(e => e.Message == errorText, e => SuccessEff(Fail(e)));
        
        /// <summary>
        /// Catch an error if the error message matches the `errorText` argument provided 
        /// </summary>
        public static EffCatch<A> match<A>(string errorText, A Fail) =>
            matchError(e => e.Message == errorText, e => SuccessEff(Fail));

                
        /// <summary>
        /// Catch an error if it's of a specific exception type
        /// </summary>
        public static EffCatch<A> match<A>(Func<Exception, bool> predicate, Func<Exception, Eff<A>> Fail) =>
            matchError(e => e.Exception.Map(predicate).IfNone(false), e => Fail(e));

        /// <summary>
        /// Catch an error if it's of a specific exception type
        /// </summary>
        public static EffCatch<A> match<A>(Func<Exception, bool> predicate, Eff<A> Fail) =>
            matchError(e => e.Exception.Map(predicate).IfNone(false), e => Fail);

        /// <summary>
        /// Catch an error if it's of a specific exception type
        /// </summary>
        public static EffCatch<A> match<A>(Func<Exception, bool> predicate, A Fail) =>
            matchError(e => e.Exception.Map(predicate).IfNone(false), e => Fail);

        /// <summary>
        /// Catch an error if it's of a specific exception type
        /// </summary>
        public static EffCatch<RT, A> match<RT, A>(Func<Exception, bool> predicate, Func<Exception, Eff<RT, A>> Fail) =>
            matchError(e => e.Exception.Map(predicate).IfNone(false), e => Fail(e));

        /// <summary>
        /// Catch an error if it's of a specific exception type
        /// </summary>
        public static EffCatch<RT, A> match<RT, A>(Func<Exception, bool> predicate, Eff<RT, A> Fail) =>
            matchError(e => e.Exception.Map(predicate).IfNone(false), e => Fail);
    }
}
