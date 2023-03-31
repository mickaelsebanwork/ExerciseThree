using System;
using AutoFixture.Xunit2;
using Exercise_3.FileReader;
using FluentAssertions;
using Moq;
using Xunit;

namespace Exercise_3.Tests
{
    public sealed class FilePrintJsonFile
    {
        [Theory]
        [AutoData]
        public void Print_WithJsonFileAndNoEncryption_WhenUserHavePermission_ShouldCallCorrespondingPorts(
            FilePrinterFixture fixture)
        {
            var request = new Request(fixture.FilePath,
                EncryptionType.NoEncryption,
                ReadOperationType.JsonFile,
                UserRoleType.RegularUser);

            var _ = fixture.Sut.Print(request);

            fixture.JsonFileReader.Verify(x => x.Read(fixture.FilePath), Times.Once);
            fixture.NoEncryption.Verify(x => x.Encrypt(fixture.ExpectedText), Times.Once);
        }


        [Theory]
        [AutoData]
        public void Print_WithJsonFileAndReverseEncryption_WhenUserHavePermission_ShouldCallCorrespondingPorts(
            FilePrinterFixture fixture)
        {
            var request = new Request(fixture.FilePath,
                EncryptionType.ReverseEncryption,
                ReadOperationType.JsonFile,
                UserRoleType.Admin);

            var _ = fixture.Sut.Print(request);

            fixture.JsonFileReader.Verify(x => x.Read(fixture.FilePath), Times.Once);
            fixture.ReverseEncryption.Verify(x => x.Encrypt(fixture.ExpectedText), Times.Once);
        }


        [Theory]
        [AutoData]
        public void
            Print_WithJsonFileAndReverseEncryption_WhenUserDoesNotHavePermission_ShouldThrowUnauthorizedAccessException(
                FilePrinterFixture fixture)
        {
            var request = new Request(fixture.FilePath,
                EncryptionType.ReverseEncryption,
                ReadOperationType.JsonFile,
                UserRoleType.GuestUser);

            var act = () => fixture.Sut.Print(request);

            act.Should().ThrowExactly<UnauthorizedAccessException>();
            fixture.JsonFileReader.Verify(x => x.Read(fixture.FilePath), Times.Never);
            fixture.ReverseEncryption.Verify(x => x.Encrypt(fixture.ExpectedText), Times.Never);
        }
    }
}