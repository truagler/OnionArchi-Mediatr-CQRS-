import {Book} from "../model/Book";

export class Converter{
    public static ToBook(data: any){
        return new Book(data.id, data.name, data.genre, data.author, data.isRemoved);
    }
    
    public static ToBooks(data: any[]){
        if(data == null) return null;
        return data.map(x => this.ToBook(x));
    }
}