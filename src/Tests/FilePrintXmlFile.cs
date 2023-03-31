using System;
using System.Collections.Generic;
using AutoFixture.Xunit2;
using Exercise_3.FileReader;
using FluentAssertions;
using Moq;
using Xunit;

namespace Exercise_3.Tests
{
    public sealed class FilePrintXmlFile
    {
        [Theory]
        [AutoData]
        public void Print_WithXmlFileAndNoEncryption_WhenUserHavePermission_ShouldCallCorrespondingPorts(
            FilePrinterFixture fixture)
        {
            var request = new Request(fixture.FilePath,
                EncryptionType.NoEncryption,
                ReadOperationType.XmlFile,
                UserRoleType.RegularUser);

            var _ = fixture.Sut.Print(request);
            fixture.XmlFileReader.Verify(x => x.Read(fixture.FilePath), Times.Once);
            fixture.NoEncryption.Verify(x => x.Encrypt(fixture.ExpectedText), Times.Once);
        }


        [Theory]
        [AutoData]
        public void Print_WithXmlFileAndReverseEncryption_WhenUserHavePermission_ShouldCallCorrespondingPorts(
            FilePrinterFixture fixture)
        {
            var request = new Request(fixture.FilePath,
                EncryptionType.ReverseEncryption,
                ReadOperationType.XmlFile,
                UserRoleType.Admin);

            var _ = fixture.Sut.Print(request);

            fixture.XmlFileReader.Verify(x => x.Read(fixture.FilePath), Times.Once);
            fixture.ReverseEncryption.Verify(x => x.Encrypt(fixture.ExpectedText), Times.Once);
        }


        [Theory]
        [AutoData]
        public void
            Print_WithXmlFileAndReverseEncryption_WhenUserDoesNotHavePermission_ShouldThrowUnauthorizedAccessException(
                FilePrinterFixture fixture)
        {
            var request = new Request(fixture.FilePath,
                EncryptionType.ReverseEncryption,
                ReadOperationType.XmlFile,
                UserRoleType.GuestUser);

            var act = () => fixture.Sut.Print(request);

            act.Should().ThrowExactly<UnauthorizedAccessException>();
            fixture.XmlFileReader.Verify(x => x.Read(fixture.FilePath), Times.Never);
            fixture.ReverseEncryption.Verify(x => x.Encrypt(fixture.ExpectedText), Times.Never);
        }
    }
}