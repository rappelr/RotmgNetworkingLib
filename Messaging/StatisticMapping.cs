namespace RotmgNetworkingLib.Reference
{
    public static class StatisticMapping
    {
        public const byte MAX_HP = 0;
        public const byte HP = 1;
        public const byte SIZE = 2;
        public const byte MAX_MP = 3;
        public const byte MP = 4;
        public const byte NEXT_LEVEL_EXP = 5;
        public const byte EXP = 6;
        public const byte LEVEL = 7;
        public const byte INVENTORY_0 = 8;
        public const byte INVENTORY_1 = 9;
        public const byte INVENTORY_2 = 10;
        public const byte INVENTORY_3 = 11;
        public const byte INVENTORY_4 = 12;
        public const byte INVENTORY_5 = 13;
        public const byte INVENTORY_6 = 14;
        public const byte INVENTORY_7 = 15;
        public const byte INVENTORY_8 = 16;
        public const byte INVENTORY_9 = 17;
        public const byte INVENTORY_10 = 18;
        public const byte INVENTORY_11 = 19;
        public const byte ATTACK = 20;
        public const byte DEFENSE = 21;
        public const byte SPEED = 22;
        public const byte SKIN = 25;
        public const byte VITALITY = 26;
        public const byte WISDOM = 27;
        public const byte DEXTERITY = 28;
        public const byte CONDITION = 29;
        public const byte NUM_STARS = 30;
        public const byte NAME = 31;
        public const byte TEX1 = 32;
        public const byte TEX2 = 33;
        public const byte MERCHANDISE_TYPE = 34;
        public const byte CREDITS = 35;
        public const byte MERCHANDISE_PRICE = 36;
        public const byte ACTIVE = 37;
        public const byte ACCOUNT_ID = 38;
        public const byte FAME = 39;
        public const byte MERCHANDISE_CURRENCY = 40;
        public const byte CONNECT = 41;
        public const byte MERCHANDISE_COUNT = 42;
        public const byte MERCHANDISE_MINS_LEFT = 43;
        public const byte MERCHANDISE_DISCOUNT = 44;
        public const byte MERCHANDISE_RANK_REQ = 45;
        public const byte MAX_HP_BOOST = 46;
        public const byte MAX_MP_BOOST = 47;
        public const byte ATTACK_BOOST = 48;
        public const byte DEFENSE_BOOST = 49;
        public const byte SPEED_BOOST = 50;
        public const byte VITALITY_BOOST = 51;
        public const byte WISDOM_BOOST = 52;
        public const byte DEXTERITY_BOOST = 53;
        public const byte OWNER_ACCOUNT_ID = 54;
        public const byte RANK_REQUIRED = 55;
        public const byte NAME_CHOSEN = 56;
        public const byte CURR_FAME = 57;
        public const byte NEXT_CLASS_QUEST_FAME = 58;
        public const byte LEGENDARY_RANK = 59;
        public const byte SINK_LEVEL = 60;
        public const byte ALT_TEXTURE = 61;
        public const byte GUILD_NAME = 62;
        public const byte GUILD_RANK = 63;
        public const byte BREATH = 64;
        public const byte XP_BOOSTED = 65;
        public const byte XP_TIMER = 66;
        public const byte LD_TIMER = 67;
        public const byte LT_TIMER = 68;
        public const byte BACKPACK_0 = 71;
        public const byte BACKPACK_1 = 72;
        public const byte BACKPACK_2 = 73;
        public const byte BACKPACK_3 = 74;
        public const byte BACKPACK_4 = 75;
        public const byte BACKPACK_5 = 76;
        public const byte BACKPACK_6 = 77;
        public const byte BACKPACK_7 = 78;
        public const byte HASBACKPACK = 79;
        public const byte TEXTURE = 80;
        public const byte PET_INSTANCEID = 81;
        public const byte PET_NAME = 82;
        public const byte PET_TYPE = 83;
        public const byte PET_RARITY = 84;
        public const byte PET_MAXABILITYPOWER = 85;
        public const byte PET_FAMILY = 86;
        public const byte PET_FIRSTABILITY_POINT = 87;
        public const byte PET_SECONDABILITY_POINT = 88;
        public const byte PET_THIRDABILITY_POINT = 89;
        public const byte PET_FIRSTABILITY_POWER = 90;
        public const byte PET_SECONDABILITY_POWER = 91;
        public const byte PET_THIRDABILITY_POWER = 92;
        public const byte PET_FIRSTABILITY_TYPE = 93;
        public const byte PET_SECONDABILITY_TYPE = 94;
        public const byte PET_THIRDABILITY_TYPE = 95;
        public const byte NEW_CON = 96;
        public const byte FORTUNE_TOKEN = 97;
        public const byte SUPPORTER_POINTS = 98;
        public const byte SUPPORTER = 99;
        public const byte CHALLENGER_STARBG = 100;
        public const byte PLAYER_ID = 101;
        public const byte PROJECTILE_SPEED_MULT = 102;
        public const byte PROJECTILE_LIFE_MULT = 103;
        public const byte OPENED_AT_TIMESTAMP = 104;
        public const byte EXALTED_ATTACK = 105;
        public const byte EXALTED_DEFENSE = 106;
        public const byte EXALTED_SPEED = 107;
        public const byte EXALTED_VITALITY = 108;
        public const byte EXALTED_WISDOM = 109;
        public const byte EXALTED_DEXTERITY = 110;
        public const byte EXALTED_HEALTH = 111;
        public const byte EXALTED_MANA = 112;
        public const byte EXALTATION_BONUS_DAMAGE = 113;
        public const byte PROJECTILE_OWNER_ID = 114;
        public const byte GRAVE_ACCOUNT_ID = 115;
        public const byte QUICKSLOT_ITEM_1 = 116;
        public const byte QUICKSLOT_ITEM_2 = 117;
        public const byte QUICKSLOT_ITEM_3 = 118;
        public const byte QUICKSLOT_UPGRADE = 119;
        public const byte FORGEFIRE = 120;
        public const byte UNKNOWN_1 = 123;

        public static bool IsStringStat(byte type)
        {
            switch (type)
            {
                case EXP:
                case NAME:
                case ACCOUNT_ID:
                case OWNER_ACCOUNT_ID:
                case GUILD_NAME:
                case TEXTURE:
                case PET_NAME:
                case GRAVE_ACCOUNT_ID:
                case UNKNOWN_1:
                    return true;
                default:
                    return false;
            }
        }
    }
}
