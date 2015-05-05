﻿using System;
using System.Windows;
using Codeer.Friendly;
using RM.Friendly.WPFStandardControls.Properties;

namespace RM.Friendly.WPFStandardControls
{
#if ENG
    /// <summary>
    /// Collection of DependencyObject in target app.
    /// </summary>
#else
    /// <summary>
    /// DependencyObjectのコレクションです。
    /// </summary>
#endif
    public class WPFDependencyObjectCollection<T> : IWPFDependencyObjectCollection<T>, IAppVarOwner where T : DependencyObject
    {
#if ENG
        /// <summary>
        /// List＜DependencyObject＞ in target app.
        /// </summary>
#else
        /// <summary>
        /// 対象プロセス内のList＜DependencyObject＞ です。
        /// </summary>
#endif
        public AppVar AppVar { get; private set; }

#if ENG
        /// <summary>
        /// Count.
        /// </summary>
#else
        /// <summary>
        /// コレクションの数。
        /// </summary>
#endif    
        public int Count { get { return (int)AppVar["Count"]().Core; } }

#if ENG
        /// <summary>
        /// DependencyObject of index in target app .
        /// </summary>
        /// <param name="index">Index.</param>
        /// <returns>DependencyObject of index in target app .</returns>
#else
        /// <summary>
        /// 対象プロセス内での指定のインデックスのDependencyObject。
        /// </summary>
        /// <param name="index">インデックス。</param>
        /// <returns>対象プロセス内での指定のインデックスのDependencyObject。</returns>
#endif
        public AppVar this[int index]
        {
            get { return AppVar["[]"](index); }
        }

        internal WPFDependencyObjectCollection(AppVar appVar)
        {
            AppVar = appVar;
        }

        internal WPFDependencyObjectCollection(IAppVarOwner appVar)
        {
            AppVar = appVar.AppVar;
        }

#if ENG
        /// <summary>
        /// Get only one item.
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// コレクションの要素が一つであることを確認してそれを取得する。
        /// </summary>
        /// <returns></returns>
#endif
        public AppVar Single()
        {
            if (Count != 1)
            {
                throw new NotSupportedException(string.Format(Resources.NotSingle, Count));
            }
            return AppVar["[]"](0);
        }
    }
}
