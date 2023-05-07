import React, { useEffect, useState} from 'react';
import { Card } from 'antd';
import {  useNavigate } from "react-router-dom";
import '../styles/Dogs.css';


const { Meta } = Card;


const Dogs = (props) => { 

    const [data,setData] = useState([]);
    const navigate = useNavigate()

    useEffect (() => {
        const requestOptions = {
            method : "GET",
            headers : { "Content-Type" : 'application/json',
               'x-api-key' : 'live_sae8Gf9mH4ZPtjuUUstRLdThlSyEH5mtH7EqH5jbnFDEud2OCChpkHTNE42ffPce'
            },
        };
    
        fetch ("https://api.thedogapi.com/v1/images/search?format=json&limit=100&order=ASC&has_breeds=1", requestOptions)
         .then(response => response.json())
         .then(data=>setData(data));         
      }, []);

      const Send = async () => {
        
        const result = await fetch('https://localhost:7108/api/Dogs', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data[0])
        })

        const  resultJson = await result.json();
        console.log(resultJson)
    }


    return ( 
        <>
        <button onClick={Send}> отправить POST запрос</button>
            <div className='Card'  >                
            {data.map((item) =>
                <button  key={item.id}  onClick={() => {
                    navigate(`/${item.id}`);
                }}>
                    
                <Card   hoverable style={{ width: 240}}
                cover={
                    <img alt="LOADING" src={item.url}/>
                }>
            <Meta title={item.breeds.map((x) => x.name)} />
            </Card>
            </button>        
            )}
            </div>
            
        </> 
    );
};


export default Dogs;