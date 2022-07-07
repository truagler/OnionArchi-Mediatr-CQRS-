import {Genre} from "../enum/Genre";

export class Book {
    public id: string;
    public name: string;
    public genre: Genre;
    public author: string;
    public isRemoved: boolean;
    
    constructor(id: string, name: string, genre: Genre, author: string, isRemoved: boolean) {
        this.id = id;
        this.name = name;
        this.genre = genre;
        this.author = author;
        this.isRemoved = isRemoved;
    }
}