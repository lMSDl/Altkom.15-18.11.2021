using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Facade.III
{
    public class ConverterFacade
    {
        private IJsonCoverter _jsonCoverter;
        private IXmlConverter _xmlConverter;
        private IByteArrayConveter _byteArrayConveter;

        public ConverterFacade(IJsonCoverter jsonCoverter, IXmlConverter xmlConverter, IByteArrayConveter byteArrayConveter)
        {
            _jsonCoverter = jsonCoverter;
            _xmlConverter = xmlConverter;
            _byteArrayConveter = byteArrayConveter;
        }

        public string ToJson()
        {
            return _jsonCoverter.ToJson();
        }
        public string ToXml()
        {
            return _xmlConverter.ToXml();
        }
        public byte[] ToByteArray()
        {
            return _byteArrayConveter.ToByteArray();
        }

    }
}
