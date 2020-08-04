
import React from "react"

function ContactCard(props) {
    console.log(props)
    return (
        <div>
        
        
        <div className="card" style = {{'width': '18rem'}}>
            <img src={props.contact.imgUrl}/>
            <h3>{props.contact.name}</h3>
            <p>Phone: {props.contact.phone}</p>
            <p>Email: {props.contact.email}</p>
        </div>
        </div>
    )
}

export default ContactCard