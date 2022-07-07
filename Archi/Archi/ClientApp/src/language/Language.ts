import {Genre} from "../enum/Genre";

export class Language{
    public static ToGenre(genre: Genre){
        switch (genre){
            case Genre.Comedy: return "Комедия";
            case Genre.Horror: return "Хоррор";
            case Genre.Detective: return "Детектив";
            case Genre.Fantastic: return "Фантастика";
            case Genre.Science: return "Наука";
        }
    }
}