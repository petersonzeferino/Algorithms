﻿using Algorithms.Application;
using Algorithms.Application.Services.Algorithms;
using Xunit;

namespace AlgorithmsTest
{
    public class AlternatingCharactersTest
    {
        [Theory(DisplayName = "Check number of deletions for alternating characters")]
        [InlineData("AAAA", 3)]
        [InlineData("BBBBB", 4)]
        [InlineData("ABABABAB", 0)]
        [InlineData("BABABA", 0)]
        [InlineData("AAABBB", 4)]
        public void CheckAlgorithmsCharactersSuccess(string input, int output)
        {
            IAlgorithmsService _algorithmsService = new AlgorithmsService();

            Assert.Equal(_algorithmsService.CheckAlgorithmsCharacter(input), output);
        }

    }
}