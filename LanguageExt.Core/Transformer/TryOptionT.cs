﻿using System;
using LanguageExt;
using System.Linq;
using System.Collections.Generic;
using LanguageExt.Common;
using LanguageExt.TypeClasses;
using static LanguageExt.Prelude;

namespace LanguageExt
{
    public static class TryOptionTExtensions
    {
        public static TryOption<Arr<B>> Traverse<A, B>(this Arr<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            var res = new B[ma.Count];
            var ix = 0;
            foreach (var xs in ma)
            {
                var x = xs();
                if (x.IsBottom) return new OptionalResult<Arr<B>>(BottomException.Default);
                if (x.IsFaulted) return new OptionalResult<Arr<B>>(x.Exception);
                if (x.IsNone) return OptionalResult<Arr<B>>.None;
                res[ix] = f(x.Value.Value);
                ix++;
            }

            return new OptionalResult<Arr<B>>(new Arr<B>(res));
        };

        public static TryOption<Either<L, B>> Traverse<L, A, B>(this Either<L, TryOption<A>> ma, Func<A, B> f) => () =>
        {
            if (ma.IsBottom)
            {
                return OptionalResult<Either<L, B>>.Bottom;
            }
            else if (ma.IsLeft)
            {
                return new OptionalResult<Either<L, B>>(Either<L, B>.Left(ma.LeftValue));
            }
            else
            {
                var mr = ma.RightValue();  
                if (mr.IsBottom) return new OptionalResult<Either<L, B>>(BottomException.Default);
                if (mr.IsFaulted) return new OptionalResult<Either<L, B>>(mr.Exception);
                if (mr.IsNone) return OptionalResult<Either<L, B>>.None;
                return new OptionalResult<Either<L, B>>(Either<L, B>.Right(f(mr.Value.Value)));
            }
        };
        
        public static TryOption<EitherUnsafe<L, B>> Traverse<L, A, B>(this EitherUnsafe<L, TryOption<A>> ma, Func<A, B> f) => () =>
        {
            if (ma.IsBottom)
            {
                return OptionalResult<EitherUnsafe<L, B>>.Bottom;
            }
            else if (ma.IsLeft)
            {
                return new OptionalResult<EitherUnsafe<L, B>>(EitherUnsafe<L, B>.Left(ma.LeftValue));
            }
            else
            {
                var mr = ma.RightValue();  
                if (mr.IsBottom) return new OptionalResult<EitherUnsafe<L, B>>(BottomException.Default);
                if (mr.IsFaulted) return new OptionalResult<EitherUnsafe<L, B>>(mr.Exception);
                if (mr.IsNone) return OptionalResult<EitherUnsafe<L, B>>.None;
                return new OptionalResult<EitherUnsafe<L, B>>(EitherUnsafe<L, B>.Right(f(mr.Value.Value)));
            }
        };

        public static TryOption<HashSet<B>> Traverse<L, A, B>(this HashSet<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            var res = new B[ma.Count];
            var ix = 0;
            foreach (var xs in ma)
            {
                var x = xs();
                if (x.IsBottom) return new OptionalResult<HashSet<B>>(BottomException.Default);
                if (x.IsFaulted) return new OptionalResult<HashSet<B>>(x.Exception);
                if (x.IsNone) return OptionalResult<HashSet<B>>.None;
                res[ix] = f(x.Value.Value);
                ix++;
            }

            return new OptionalResult<HashSet<B>>(new HashSet<B>(res));
        };

        public static TryOption<Identity<B>> Traverse<L, A, B>(this Identity<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            var mr = ma.Value();
            if (mr.IsBottom) return new OptionalResult<Identity<B>>(BottomException.Default);
            if (mr.IsFaulted) return new OptionalResult<Identity<B>>(mr.Exception);
            if (mr.IsNone) return OptionalResult<Identity<B>>.None;
            return new OptionalResult<Identity<B>>(new Identity<B>(f(mr.Value.Value)));
        };

        public static TryOption<Lst<B>> Traverse<L, A, B>(this Lst<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            var res = new B[ma.Count];
            var ix = 0;
            foreach (var xs in ma)
            {
                var x = xs();
                if (x.IsBottom) return new OptionalResult<Lst<B>>(BottomException.Default);
                if (x.IsFaulted) return new OptionalResult<Lst<B>>(x.Exception);
                if (x.IsNone) return OptionalResult<Lst<B>>.None;
                res[ix] = f(x.Value.Value);
                ix++;
            }

            return new OptionalResult<Lst<B>>(new Lst<B>(res));
        };

        public static TryOption<Option<B>> Traverse<A, B>(this Option<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            if (ma.IsNone) return new OptionalResult<Option<B>>(Option<B>.None);
            var mr = ma.Value();
            if (mr.IsBottom) return new OptionalResult<Option<B>>(BottomException.Default);
            if (mr.IsFaulted) return new OptionalResult<Option<B>>(mr.Exception);
            if (mr.IsNone) return OptionalResult<Option<B>>.None;
            return new OptionalResult<Option<B>>(Option<B>.Some(f(mr.Value.Value)));
        };
        
        public static TryOption<OptionUnsafe<B>> Traverse<A, B>(this OptionUnsafe<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            if (ma.IsNone) return new OptionalResult<OptionUnsafe<B>>(OptionUnsafe<B>.None);
            var mr = ma.Value();
            if (mr.IsBottom) return new OptionalResult<OptionUnsafe<B>>(BottomException.Default);
            if (mr.IsFaulted) return new OptionalResult<OptionUnsafe<B>>(mr.Exception);
            if (mr.IsNone) return OptionalResult<OptionUnsafe<B>>.None;
            return new OptionalResult<OptionUnsafe<B>>(OptionUnsafe<B>.Some(f(mr.Value.Value)));
        };

        public static TryOption<Que<B>> Traverse<L, A, B>(this Que<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            var res = new B[ma.Count];
            var ix = 0;
            foreach (var xs in ma)
            {
                var x = xs();
                if (x.IsBottom) return new OptionalResult<Que<B>>(BottomException.Default);
                if (x.IsFaulted) return new OptionalResult<Que<B>>(x.Exception);
                if (x.IsNone) return OptionalResult<Que<B>>.None;
                res[ix] = f(x.Value.Value);
                ix++;
            }

            return new OptionalResult<Que<B>>(new Que<B>(res));
        };

        public static TryOption<Seq<B>> Traverse<L, A, B>(this Seq<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            var res = new B[ma.Count];
            var ix = 0;
            foreach (var xs in ma)
            {
                var x = xs();
                if (x.IsBottom) return new OptionalResult<Seq<B>>(BottomException.Default);
                if (x.IsFaulted) return new OptionalResult<Seq<B>>(x.Exception);
                if (x.IsNone) return OptionalResult<Seq<B>>.None;
                res[ix] = f(x.Value.Value);
                ix++;
            }

            return new OptionalResult<Seq<B>>(Seq.FromArray(res));
        };

        public static TryOption<IEnumerable<B>> Traverse<L, A, B>(this IEnumerable<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            var res = new List<B>();
            foreach (var xs in ma)
            {
                var x = xs();
                if (x.IsBottom) return new OptionalResult<IEnumerable<B>>(BottomException.Default);
                if (x.IsFaulted) return new OptionalResult<IEnumerable<B>>(x.Exception);
                if (x.IsNone) return OptionalResult<IEnumerable<B>>.None;
                res.Add(f(x.Value.Value));
            }

            return new OptionalResult<IEnumerable<B>>(res);
        };

        public static TryOption<Set<B>> Traverse<L, A, B>(this Set<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            var res = new B[ma.Count];
            var ix = 0;
            foreach (var xs in ma)
            {
                var x = xs();
                if (x.IsBottom) return new OptionalResult<Set<B>>(BottomException.Default);
                if (x.IsFaulted) return new OptionalResult<Set<B>>(x.Exception);
                if (x.IsNone) return OptionalResult<Set<B>>.None;
                res[ix] = f(x.Value.Value);
                ix++;
            }

            return new OptionalResult<Set<B>>(new Set<B>(res));
        };

        public static TryOption<Stck<B>> Traverse<L, A, B>(this Stck<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            var res = new B[ma.Count];
            var ix = 0;
            foreach (var xs in ma)
            {
                var x = xs();
                if (x.IsBottom) return new OptionalResult<Stck<B>>(BottomException.Default);
                if (x.IsFaulted) return new OptionalResult<Stck<B>>(x.Exception);
                if (x.IsNone) return OptionalResult<Stck<B>>.None;
                res[ix] = f(x.Value.Value);
                ix++;
            }

            return new OptionalResult<Stck<B>>(new Stck<B>(res));
        };
        
        public static TryOption<Try<B>> Traverse<L, A, B>(this Try<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            var mb = ma();
            if (mb.IsBottom) return default;
            if (mb.IsFaulted) return new OptionalResult<Try<B>>(mb.Exception);
            var mr = mb.Value();
            if (mr.IsBottom) return default;
            if (mr.IsFaulted) return new OptionalResult<Try<B>>(mr.Exception);
            if (mr.IsNone) return OptionalResult<Try<B>>.None;
            return new OptionalResult<Try<B>>(Try<B>(f(mr.Value.Value)));
        };
        
        public static TryOption<TryOption<B>> Traverse<L, A, B>(this TryOption<TryOption<A>> ma, Func<A, B> f) => () =>
        {
            var mb = ma();
            if (mb.IsBottom) return default;
            if (mb.IsFaulted) return new OptionalResult<TryOption<B>>(mb.Exception);
            if (mb.Value.IsNone) return new OptionalResult<TryOption<B>>(TryOption<B>(Option<B>.None));
            var mr = mb.Value.Value();
            if (mr.IsBottom) return default;
            if (mr.IsFaulted) return new OptionalResult<TryOption<B>>(mr.Exception);
            if (mr.IsNone) return OptionalResult<TryOption<B>>.None;
            return new OptionalResult<TryOption<B>>(TryOption<B>(f(mr.Value.Value)));
        };
        
        public static TryOption<Validation<L, B>> Traverse<L, A, B>(this Validation<L, TryOption<A>> ma, Func<A, B> f) => () =>
        {
            if (ma.IsFail) return new OptionalResult<Validation<L, B>>(Validation<L, B>.Fail(ma.FailValue));
            var mr = ma.SuccessValue();  
            if (mr.IsBottom) return new OptionalResult<Validation<L, B>>(BottomException.Default);
            if (mr.IsFaulted) return new OptionalResult<Validation<L, B>>(mr.Exception);
            if (mr.IsNone) return OptionalResult<Validation<L, B>>.None;
            return new OptionalResult<Validation<L, B>>(Validation<L, B>.Success(f(mr.Value.Value)));
        };

        public static TryOption<Validation<MonoidL, L, B>> Traverse<MonoidL, L, A, B>(
            this Validation<MonoidL, L, TryOption<A>> ma, Func<A, B> f)
            where MonoidL : struct, Monoid<L>, Eq<L> => () =>
        {
            if (ma.IsFail) return new OptionalResult<Validation<MonoidL, L, B>>(Validation<MonoidL, L, B>.Fail(ma.FailValue));
            var mr = ma.SuccessValue();  
            if (mr.IsBottom) return new OptionalResult<Validation<MonoidL, L, B>>(BottomException.Default);
            if (mr.IsFaulted) return new OptionalResult<Validation<MonoidL, L, B>>(mr.Exception);
            if (mr.IsNone) return OptionalResult<Validation<MonoidL, L, B>>.None;
            return new OptionalResult<Validation<MonoidL, L, B>>(Validation<MonoidL, L, B>.Success(f(mr.Value.Value)));
        };
    }
}
