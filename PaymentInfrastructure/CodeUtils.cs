//-----------------------------------------------------------------------
// Представляет работу с кодовыми таблицами слов.
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BookMarket.PaymentInfrastructure
{
    //Класс работы с кодировками символов
    public class CodeUtils
    {
        public CodeUtils()
        {
        }

        //Перекодирует value из кодировки encoder в кодировку decoder
        public string Decode(Encoding encoder, Encoding decoder, string value)
        {
            byte[] intByteBuff, charBuff, outByteBuff, codeBytes;
            char[] chars;

            codeBytes = new byte[encoder.GetByteCount(value)];
            encoder.GetBytes(value, 0, value.Length, codeBytes, 0);
            chars = decoder.GetChars(codeBytes);

            return new string(chars);
        }
    }
}