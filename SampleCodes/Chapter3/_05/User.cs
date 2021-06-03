using System;

namespace _05
{
    /*
     * オブジェクトの同一性を判別す津ために識別子を追加
     * ユーザ名が変更されても同一のユーザとして認識できる
     */
    
    class User
    {
        private readonly UserId id; // 識別子
        private string name;

        public User(UserId id, string name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            this.id = id;
            ChangeUserName(name);
        }

        public void ChangeUserName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name.Length < 3) throw new ArgumentException("ユーザ名は３文字以上です。", nameof(name));

            this.name = name;
        }
    }
}
