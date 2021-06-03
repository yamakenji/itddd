using System;

namespace _09
{
    /*
     * 饒舌なコード
     * 開発者は存在するルールを確認できる
     * 
     */
    class UserName
    {
        private readonly string value;

        public UserName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length < 3) throw new ArgumentException("ユーザ名は３文字以上です。", nameof(value));

            this.value = value;
        }

        public string Value => value;
    }
}
