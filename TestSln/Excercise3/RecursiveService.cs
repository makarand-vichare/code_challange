using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise3
{
    public class RecursiveService
    {
        private int carry = 0;
        private byte[] CallRecursive(byte[] firstArray, byte[] secondArray)
        {

            if (firstArray.Length == 0) return new byte[] { };
            int tempresult = firstArray[0] + secondArray[0] + carry;
            byte[] finalArray = new byte[] { (byte)(tempresult) };

            carry = tempresult / (byte.MaxValue + 1);
            return finalArray.Concat(CallRecursive(firstArray.Skip(1).ToArray(), secondArray.Skip(1).ToArray())).ToArray();
        }

        public byte[] AddRecursive(byte[] firstArray, byte[] secondArray)
        {
            firstArray = firstArray.Reverse().ToArray();
            secondArray = secondArray.Reverse().ToArray();

            byte[] finalArray = CallRecursive(firstArray, secondArray);

            return finalArray.Reverse().ToArray();
        }

        public ServiceResult<byte[]> ValidateArray(string[] arrayItems)
        {
            var result = new ServiceResult<byte[]>();
            try
            {
                if (arrayItems == null || arrayItems.Length <= 0)
                {
                    result.Message = AppConstants.INPUT_INVALID;
                    return result;
                }

                var byteArrayItems = new List<byte>();
                var isValid = false;
                foreach (var arrayItem in arrayItems)
                {
                    isValid = Byte.TryParse(arrayItem, out byte byteArrayItem);
                    if (!isValid)
                    {
                        result.Message = string.Format(AppConstants.INPUT_INVALID_BYTE_VALUE, AppConstants.MIN_BYTE_VALUE, AppConstants.MAX_BYTE_VALUE);
                        break;
                    }

                    byteArrayItems.Add(byteArrayItem);
                }

                if (!isValid)
                {
                    return result;
                }

                result.Data = byteArrayItems.ToArray();
                result.IsSucceed = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
