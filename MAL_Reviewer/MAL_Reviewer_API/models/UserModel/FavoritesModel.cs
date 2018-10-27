namespace MAL_Reviewer_API.models
{
    public class FavoritesModel
    {
        public FavAnimeModel[] anime;
        public FavMangaModel[] manga;
        public FavCharactersModel[] characters;
        public FavPeopleModel[] people;
    }

    public class FavTargetModel
    {
        public int mal_id;
        public string url;
        public string image_url;
        public string name;
    }

    public class FavAnimeModel : FavTargetModel { }

    public class FavMangaModel : FavTargetModel { }

    public class FavCharactersModel : FavTargetModel { }

    public class FavPeopleModel : FavTargetModel { }
}
