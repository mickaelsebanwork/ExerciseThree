using System;
using AutoFixture.Xunit2;
using Exercise_3.FileReader;
using FluentAssertions;
using Moq;
using Xunit;

namespace Exercise_3.Tests
{
    public sealed class FilePrintTextFile
    {
        [Theory]
        [AutoData]
        public void Print_WithTextFileAndNoEncryption_WhenUserHavePermission_ShouldCallCorrespondingPorts(
            FilePrinterFixture fixture)
        {
            var request = new Request(fixture.FilePath,
                EncryptionType.NoEncryption,
                ReadOperationType.TextFile,
                UserRoleType.GuestUser);

            var _ = fixture.Sut.Print(request);

            fixture.TextFileReader.Verify(x => x.Read(fixture.FilePath), Times.Once);
            fixture.NoEncryption.Verify(x => x.Encrypt(fixture.ExpectedText), Times.Once);
        }


        [Theory]
        [AutoData]
        public void Print_WithTextFileAndReverseEncryption_WhenUserHavePermission_ShouldCallCorrespondingPorts(
            FilePrinterFixture fixture)
        {
            var request = new Request(fixture.FilePath,
                EncryptionType.ReverseEncryption,
                ReadOperationType.TextFile,
                UserRoleType.RegularUser);

            var _ = fixture.Sut.Print(request);

            fixture.TextFileReader.Verify(x => x.Read(fixture.FilePath), Times.Once);
            fixture.ReverseEncryption.Verify(x => x.Encrypt(fixture.ExpectedText), Times.Once);
        }


        [Theory]
        [AutoData]
        public void
            Print_WithTextFileAndReverseEncryption_WhenUserDoesNotHavePermission_ShouldThrowUnauthorizedAccessException(
                FilePrinterFixture fixture)
        {
            var request = new Request(fixture.FilePath,
                EncryptionType.ReverseEncryption,
                ReadOperationType.TextFile,
                UserRoleType.GuestUser);

            var act = () => fixture.Sut.Print(request);
            act.Should().ThrowExactly<UnauthorizedAccessException>();
            fixture.TextFileReader.Verify(x => x.Read(fixture.FilePath), Times.Never);
            fixture.ReverseEncryption.Verify(x => x.Encrypt(fixture.ExpectedText), Times.Never);
        }
    }
}