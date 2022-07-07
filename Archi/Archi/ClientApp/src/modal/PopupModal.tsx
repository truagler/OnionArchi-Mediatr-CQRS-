import React, {ChangeEvent, Component} from "react";
import {Book} from "../model/Book";
import {Modal, ModalBody, ModalFooter, ModalHeader} from "reactstrap";
import {Genre} from "../enum/Genre";
import axios from "axios";
import {Language} from "../language/Language";

type State = {
    name: string | null;
    genre: Genre | null;
    author: string | null;
}

type Props = {
    book: Book | null;
    isShown: boolean
    close: () => void;
    getBooks: () => void;
}

export class PopupModal extends Component<Props, State>{
    constructor(props: any) {
        super(props);
        
        this.state = {
            name: null,
            genre: null,
            author: null
        }
    }
    
    async addBook(){
        const bookDto = {'id': null, 'name': this.state.name, 'genre': this.state.genre, 'author': this.state.author, 'isRemoved': false };
        await axios.post('/addbook', bookDto);
        this.props.close();
        this.props.getBooks();
    }
    
    async updateBook(){
        const bookDto = {'id': this.props.book!.id, 'name': this.state.name ?? this.props.book?.name, 'genre': this.state.genre ?? this.props.book?.genre, 'author': this.state.author ?? this.props.book?.author, 'isRemoved': false };
        debugger
        await axios.post('/updatebook', bookDto);
        this.props.close();
        this.props.getBooks();
    }
    
    updateName(e: ChangeEvent<HTMLInputElement>){
        const name = e.target.value.toString();
        this.setState({name: name})
    }
    
    updateAuthor(e: ChangeEvent<HTMLInputElement>){
        const author = e.target.value.toString();
        this.setState({author: author})
    }
    
    updateGenre(e: ChangeEvent<HTMLSelectElement>){
        const genre = Number(e.target.value);
        this.setState({genre: genre})
    }
    
    render() {
        return (
            <div>
                <Modal 
                    size="lg"
                    aria-labelledby="contained-modal-title-vcenter"
                    isOpen={this.props.isShown}
                    fade={false}
                >
                    <ModalHeader>
                        <h1>{this.props.book != null ? "Редактирование книги" : "Добавление книги"}</h1>
                    </ModalHeader>
                    <ModalBody>
                        <div>
                            <p>Название книги: </p><input defaultValue={this.props.book?.name ?? ""} onChange={(e) => this.updateName(e)} type="text"/>
                        </div>
                        <div>
                            <p>Жанр книги: </p> 
                            <select onChange={(e) => this.updateGenre(e)} defaultValue={this.props.book?.genre ?? Genre.Comedy}>
                                <option value={1}>{Language.ToGenre(1)}</option>
                                <option value={2}>{Language.ToGenre(2)}</option>
                                <option value={3}>{Language.ToGenre(3)}</option>
                                <option value={4}>{Language.ToGenre(4)}</option>
                                <option value={5}>{Language.ToGenre(5)}</option>
                            </select>
                        </div>
                        <div>
                            <p>Автор книги: </p><input defaultValue={this.props.book?.author ?? ""} onChange={(e) => this.updateAuthor(e)} type="text"/>
                        </div>
                    </ModalBody>
                    <ModalFooter>
                        <button className="btn btn-success" onClick={this.props.book != null ? () => this.updateBook() : () => this.addBook()}>{this.props.book != null ? "Редактировать" : "Добавить"}</button>
                        <button className="btn btn-danger" onClick={() => this.props.close()}>Закрыть</button>
                    </ModalFooter>
                </Modal>
            </div>
        );
    }
}