import React, {Component, useEffect, useState} from 'react';
import {Book} from "../model/Book";
import {Converter} from "../converter/Converter";
import {Language} from "../language/Language";
import axios from "axios";
import {PopupModal} from "../modal/PopupModal";

export function FetchData() {
    
    const [books, setBooks] = useState<Book[] | null>(null);
    const [book, setBook] = useState<Book | null>(null);
    const [isShow, setIsShow] = useState<boolean>(false);
    
    useEffect(()=>{
        getBooks();
        }, []);

    async function getBooks() {
        const axios = require('axios');
        const result = await axios.get('getbooks');
        const books = Converter.ToBooks(result.data.result);
        setBooks(books);
    }
    
    async function getBook(id: string){
        const axios = require('axios');
        const result = await axios.get('getbook/', {params: {
                id: id
            }});
        const book = Converter.ToBook(result.data.result);
        setBook(book);
        setIsShow(true);
    }
    
    function onClose(){
        setIsShow(false);
    }
    
    function onOpen(){
        setBook(null);
        setIsShow(true);
    }
    
        return (
            <div>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                    <tr>
                        <th>Имя</th>
                        <th>Жанр</th>
                        <th>Автор</th>
                        <th>Удалено/Не удалено</th>
                        <th><button className="btn btn-success" onClick={() => onOpen()}>Добавить</button></th>
                    </tr>
                    </thead>
                    <tbody>
                    {
                        books?.map(bk => 
                            <tr key={bk.id}>
                                <td><b onClick={() => getBook(bk.id)}>{bk.name}</b></td>
                                <td>{Language.ToGenre(bk.genre)}</td>
                                <td>{bk.author}</td>
                                <td aria-disabled>{bk.isRemoved ? "Удален" : "Не удален"}</td>
                                <td></td>
                            </tr>
                        )
                    }
                    </tbody>
                </table>
                <PopupModal book={book} isShown={isShow} close={() => onClose()} getBooks={() => getBooks()}/>
            </div>
        );
}
