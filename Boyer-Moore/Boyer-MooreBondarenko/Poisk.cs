using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boyer_MooreBondarenko
{
    abstract class SearchBase
    {
        public const int InvalidIndex = -1;
        protected string _pattern;
        public SearchBase(string pattern) { _pattern = pattern; }
        public abstract int Search(string text, int startIndex);
        public int Search(string text) { return Search(text, 0); }
    }
    class BoyerMoore : SearchBase
    {
        private int[] _goodSuffixShift;
        private byte[] _badCharShift;

        public BoyerMoore(string pattern)
            : base(pattern)
        {
            BuildGoodSuffixShift();
            BuildBadCharacterShift();
        }
        private void BuildGoodSuffixShift()
        {
            int i, j;
            _goodSuffixShift = new int[_pattern.Length];

            int[] suff = new int[_pattern.Length];

            FindSuffixes(suff);

            for (i = 0; i < _pattern.Length; ++i)
                _goodSuffixShift[i] = _pattern.Length;
            j = 0;
            for (i = _pattern.Length - 1; i >= 0; --i)
            {
                if (suff[i] == i + 1)
                    for (; j < _pattern.Length - 1 - i; ++j)
                        if (_goodSuffixShift[j] == _pattern.Length)
                            _goodSuffixShift[j] = _pattern.Length - 1 - i;
            }
            for (i = 0; i <= _pattern.Length - 2; ++i)
                _goodSuffixShift[_pattern.Length - 1 - suff[i]] = _pattern.Length - 1 - i;
        }
        void FindSuffixes(int[] suff)
        {
            int f = 0, g, i;

            suff[_pattern.Length - 1] = _pattern.Length;
            g = _pattern.Length - 1;
            for (i = _pattern.Length - 2; i >= 0; --i)
            {
                if (i > g && suff[i + _pattern.Length - 1 - f] < i - g)
                    suff[i] = suff[i + _pattern.Length - 1 - f];
                else
                {
                    if (i < g)
                        g = i;
                    f = i;
                    while (g >= 0 && _pattern[g] == _pattern[g + _pattern.Length - 1 - f])
                        --g;
                    suff[i] = f - g;
                }
            }
        }
        private void BuildBadCharacterShift()
        {
            _badCharShift = new byte[0x10000];

            for (int i = 0; i < _badCharShift.Length; i++)
                _badCharShift[i] = (byte)_pattern.Length;
            for (int i = 0; i < _pattern.Length - 1; i++)
                _badCharShift[_pattern[i]] = (byte)(_pattern.Length - i - 1);
        }
        public override int Search(string text, int startIndex)
        {
            int i = startIndex;
            while (i <= (text.Length - _pattern.Length))
            {
                int j = _pattern.Length - 1;
                while (j >= 0 && _pattern[j] == text[i + j])
                    j--;

                if (j < 0)
                {
                    return i;
                }
                else
                {
                    i += Math.Max(_goodSuffixShift[j],
                        _badCharShift[text[i + j]] - _pattern.Length + 1 + j);
                }
            }
            return InvalidIndex;
        }
    }
    class BoyerMoore2 : SearchBase
    {
        private byte[] _skipArray;

        public BoyerMoore2(string pattern)
            : base(pattern)
        {
            _skipArray = new byte[0x10000];

            for (int i = 0; i < _skipArray.Length; i++)
                _skipArray[i] = (byte)_pattern.Length;
            for (int i = 0; i < _pattern.Length - 1; i++)
                _skipArray[_pattern[i]] = (byte)(_pattern.Length - i - 1);

        }

        public override int Search(string text, int startIndex)
        {
            int i = startIndex;
            while (i <= (text.Length - _pattern.Length))
            {
                int j = _pattern.Length - 1;
                while (j >= 0 && _pattern[j] == text[i + j])
                    j--;

                if (j < 0)
                {
                    return i;
                }
                i += Math.Max(_skipArray[text[i + j]] - _pattern.Length + 1 + j, 1);
            }
            return InvalidIndex;
        }
    }
    class IndexOf : SearchBase
    {
        public IndexOf(string pattern)
            : base(pattern)
        {
        }

        public override int Search(string text, int startIndex)
        {
            return text.IndexOf(_pattern, startIndex, StringComparison.Ordinal);
        }
    }
}
