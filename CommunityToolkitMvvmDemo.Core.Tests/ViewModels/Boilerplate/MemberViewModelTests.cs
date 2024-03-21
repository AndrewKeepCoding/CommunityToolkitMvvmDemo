using CommunityToolkitMvvmDemo.Core.Models;
using CommunityToolkitMvvmDemo.Core.ViewModels.Boilerplate;
using FluentAssertions;

namespace CommunityToolkitMvvmDemo.Core.Tests.ViewModels.Boilerplate;

public class MemberViewModelTests
{
    // Memberdata
    public static IEnumerable<object[]> FullNameTestData =>
        [
            [new[] { "Ted" }, "Ted"],
            [new[] { "Ted", "Mosby" }, "Ted Mosby"],
            [new[] { "Theodore", "Evelyn", "Mosby" }, "Theodore Evelyn Mosby"],
        ];

    [Theory]
    [MemberData(nameof(FullNameTestData))]
    public void FullName_ReturnsExpectedValue(string[] names, string expected)
    {
        // Arrange
        Member member = new(
            firstName: names.Length > 0 ? names[0] : string.Empty,
            middleName: names.Length > 1 ? names[1] : string.Empty,
            lastName: names.Length > 2 ? names[2] : string.Empty);
        MemberViewModel sut = new(member);

        // Act
        string result = sut.FullName;

        // Assert
        result.Should().Be(expected);
    }
}
