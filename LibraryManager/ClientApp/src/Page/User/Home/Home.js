import { Card } from 'antd';
import { GetBooks } from '../../../Api/BookApi'
import { GetCategories } from '../../../Api/CategoryApi'
import { useState,useEffect } from 'react';
const { Meta } = Card;
const Home = () => {
    const [books,setBooks] =useState([])
    const [categories,setCategories] = useState([])

    useEffect(()=>{
        setCategories(GetCategories())
        setUsers(GetBooks())
    })
    return (
        <div>
        {
            categories.map(category=>{
                return(
                    
                )
            })
        }
        </div>
    )
}
export default Home;