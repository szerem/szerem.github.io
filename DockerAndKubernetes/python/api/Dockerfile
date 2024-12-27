FROM python:3

WORKDIR /app

EXPOSE 5050

COPY . ./
# COPY ./*.py ./
# COPY ./requirements.txt ./

RUN pip install -r requirements.txt

CMD [ "python", "./main.py" ]
