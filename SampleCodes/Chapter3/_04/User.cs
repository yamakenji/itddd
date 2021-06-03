using System;

namespace _04
{
    /*
     * Userクラスに識別子としてUserIdを追加
     */
    class User
    {
        private readonly UserId id; // 識別子
        private string name;

        public User(UserId id, string name)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (name == null) throw new ArgumentNullException(nameof(name));

            this.id = id;
            this.name = name;
        }
    }
}
