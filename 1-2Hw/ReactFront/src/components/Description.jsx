import React, {useState, useEffect} from "react";
import { useParams } from "react-router-dom";
import { Card } from "antd";

const Description = () => {
    const params = useParams(); 

    const [data,setData] = useState([]);

    useEffect (() => {
        const requestOptions = {
            method : "GET",
            headers : { "Content-Type" : 'application/json',
              'x-api-key' : 'live_sae8Gf9mH4ZPtjuUUstRLdThlSyEH5mtH7EqH5jbnFDEud2OCChpkHTNE42ffPce'
            },
        };
    
        fetch (`https://api.thedogapi.com/v1/images/${params.id}`, requestOptions)
         .then(response => response.json())
         .then(data=>setData(data));         
      }, []);      
        

    return(
        <Card  style={{ width: 240}}
                cover={
                        <img alt="Loading" src={data.url}/>
                    }>
                <p>{data.breeds?.map((x) => x.name)}</p>
                <p>{data.breeds?.map((x) => x.temperament)}</p>
                
            </Card>
    )        
        
}

export default Description;