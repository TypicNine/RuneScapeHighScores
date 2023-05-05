


using RuneScapeHiScores;

var client = new HttpClient();

client.BaseAddress = new Uri("http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=");

Console.WriteLine("Enter Old School Runescape Username: ");

string userName = Console.ReadLine();

userName.Replace(" ", "+");

Uri rsnHighscore = new Uri(client.BaseAddress + userName);

HttpResponseMessage response = await client.GetAsync(rsnHighscore);

var responseData = await response.Content.ReadAsStringAsync();

string responseString = responseData.ToString();

char[] separators = new char[] { ',', '\n' };

List<string> scores = responseString.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

List<string> skills = new List<string>
{
    "Overall",
    "Attack",
    "Defence",
    "Strength",
    "Hitpoints",
    "Ranged",
    "Prayer",
    "Magic",
    "Cooking",
    "Woodcutting",
    "Fletching",
    "Fishing",
    "Firemaking",
    "Crafting",
    "Smithing",
    "Mining",
    "Herblore",
    "Agility",
    "Thieving",
    "Slayer",
    "Farming",
    "Runecraft",
    "Hunter",
    "Construction"
};

List<Skills> SkillList = new List<Skills>();

  var counter = 0;




foreach (var item in skills)
{
    var skillStats = new Skills()
    {
        SkillName = item,
        Rank = scores[counter],
        Level = scores[counter + 1],
        XP = scores[counter + 2]
    };
    counter += 3;
    SkillList.Add(skillStats);
}

foreach (var item in SkillList)
{
    Console.WriteLine($"SkillName: {item.SkillName} \n" +
        $"Rank: {item.Rank} \n" +
        $"Level: {item.Level} \n" +
        $"XP: {item.XP}");
}

var dbConnection = "yada";